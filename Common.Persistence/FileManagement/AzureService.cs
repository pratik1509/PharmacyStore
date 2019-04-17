using Common.Persistence.FileManagement.FileDto;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Common.Persistence.FileManagement
{
    public class AzureService : IFileService
    {
        private readonly Dictionary<QueueDto, CloudQueue> _cloudQueues;
        private readonly string _connectionString;
        private readonly string _queueconnectionString;
        private readonly bool _isDevelopment;

        public AzureService(AzureSettings azureSettings)
        {
            _connectionString = azureSettings.ConnectionString;
            _queueconnectionString = azureSettings.QueueConnectionString;
            _cloudQueues = new Dictionary<QueueDto, CloudQueue>();
            _isDevelopment = azureSettings.IsDevelopment;
        }

        public async Task AddMessage(object message, QueueDto queue, TimeSpan? initialVisibilityDelay = null)
        {
            var str = Jil.JSON.Serialize(message);
            await _cloudQueues[queue].AddMessageAsync(new CloudQueueMessage(str));
        }

        public CloudBlockBlob GetBlobUploadFile(string containername, string filename)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(containername);
            return container.GetBlockBlobReference(filename);
        }
        
        public async Task GetQueueClient()
        {
            CloudQueueClient client = null;
          
                client = CloudStorageAccount.Parse(_queueconnectionString).CreateCloudQueueClient();

            foreach (var enumqueue in new[] { QueueDto.Mail })
            {
                var queue = client.GetQueueReference(Enum.GetName(typeof(QueueDto), enumqueue).ToLower());
                await queue.CreateIfNotExistsAsync();
                _cloudQueues.Add(enumqueue, queue);
            }
        }

        public async Task UploadFiles(IFormFileCollection files)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    using (var fileStream = file.OpenReadStream())
                    {
                        string fileName = string.Format("{0}-{1}", System.DateTime.Now.Ticks, file.FileName);
                        var blob = GetBlobUploadFile("videoDoctorFiles", fileName);
                        blob.Properties.ContentType = file.ContentType;
                        await blob.UploadFromStreamAsync(fileStream);
                    }
                }
            }
        }

        public async Task UploadFilesUsingByte(UploadedFilesUsingByteDto uploadedfile)
        {
            if (uploadedfile != null)
            {
                foreach (var file in uploadedfile.UplodedFiles)
                {
                    using (var fileStream = new MemoryStream(file.File))
                    {
                        var blob = GetBlobUploadFile("videodoctorfiles", file.FileName );
                        await blob.UploadFromStreamAsync(fileStream);
                    }
                }
            }
        }

        public async Task<BlobUriWithSasDto> GetBlobUrl(FileUploadDetailRequestDto dto)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            #region setting cors

            // Given a BlobClient, download the current Service Properties 
            ServiceProperties blobServiceProperties = await blobClient.GetServicePropertiesAsync();
            // Enable and Configure CORS
            ConfigureCors(blobServiceProperties);
            // Commit the CORS changes into the Service Properties
            await blobClient.SetServicePropertiesAsync(blobServiceProperties);

            #endregion


            CloudBlobContainer container = blobClient.GetContainerReference(dto.ContainerName);
            var containerUri = container.Uri; // finds required container and returns url for that container

            // Create the container if it doesn't already exist
            await container.CreateIfNotExistsAsync();

            var blob = container.GetBlockBlobReference(dto.BlobName);

            // create signature that will allow to write for next 10 mins
            var sas = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
            {
                Permissions = SharedAccessBlobPermissions.Write,
                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(10),
            });

            return new BlobUriWithSasDto()
            {
                Sas = sas,
                BaseUri = containerUri.ToString(),
                BlobName = dto.BlobName,
            };
        }

        private static void ConfigureCors(ServiceProperties serviceProperties)
        {
            serviceProperties.Cors = new CorsProperties();
            serviceProperties.Cors.CorsRules.Add(new CorsRule()
            {
                AllowedHeaders = new List<string>() { "*" },
                AllowedMethods = CorsHttpMethods.Put | CorsHttpMethods.Get | CorsHttpMethods.Head | CorsHttpMethods.Post,
                AllowedOrigins = new List<string>() { "*" },
                ExposedHeaders = new List<string>() { "*" },
                MaxAgeInSeconds = 1800 // 30 minutes
            });
        }
    }
}
