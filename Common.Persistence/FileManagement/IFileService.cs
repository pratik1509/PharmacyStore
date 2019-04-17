using Common.Persistence.FileManagement.FileDto;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Persistence.FileManagement
{
    public interface IFileService
    {
        Task AddMessage(object message, QueueDto queue, TimeSpan? initialVisibilityDelay = null);
        Task GetQueueClient();
        CloudBlockBlob GetBlobUploadFile(string containername, string filename);
        Task UploadFiles(IFormFileCollection files);
        Task UploadFilesUsingByte(UploadedFilesUsingByteDto uploadedfile);
        Task<BlobUriWithSasDto> GetBlobUrl(FileUploadDetailRequestDto id);
    }
}
