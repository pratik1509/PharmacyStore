namespace Common.Persistence.WebSocketManagement
{
    public class PusherSettings
    {
        public string Cluster { get; set; }
        public bool IsEncrypted { get; set; }
        public string AppId { get; set; }
        public string Key { get; set; }
        public string Secret { get; set; }
    }
}
