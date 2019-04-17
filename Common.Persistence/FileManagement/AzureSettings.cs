namespace Common.Persistence.FileManagement
{
    public class AzureSettings
    {
        public string ConnectionString { get; set; }
        public string QueueConnectionString { get; set; }
        public bool IsDevelopment { get; set; }
    }
}
