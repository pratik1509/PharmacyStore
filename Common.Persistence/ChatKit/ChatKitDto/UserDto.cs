using System;

namespace Common.Persistence.ChatKit.ChatKitDto
{
    public class UserDto
    {
        public string name { get; set; }
        public string id { get; set; }
        public string avatar_url { get; set; }
        public string custom_data { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
