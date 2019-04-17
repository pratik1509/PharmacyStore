using System;

namespace Common.Persistence.VideoCallManagement
{
    public class TwilioConfiguration
    {
        public string ApiKey { get; set; }
        public string ApiAccountSid { get; set; }
        public string ApiKeySecret { get; set; }
        public string AccountSid { get; set; }
        public DateTime ExpiryTime { get; set; }
    }
}
