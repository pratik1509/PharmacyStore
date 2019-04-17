namespace Common.Persistence.FileManagement.FileDto
{
    public class BlobUriWithSasDto
    {
        public string Sas { get; set; }
        public string BaseUri { get; set; }
        public string BlobName { get; set; }
    }
}
