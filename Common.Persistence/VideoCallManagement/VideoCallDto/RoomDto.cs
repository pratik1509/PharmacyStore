using System;

namespace Common.Persistence.VideoCallManagement.VideoCallDto
{
    public class RoomDto
    {
        public string RoomSid { get; set; }
        public string UniqueName { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
