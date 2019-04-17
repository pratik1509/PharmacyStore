using System;
using System.Collections.Generic;

namespace Common.Persistence.VideoCallManagement.VideoCallDto
{
    public class CompositionDto
    {
        public string CompositionSid { get; set; }
        public Uri Url { get; set; }
        public Dictionary<string, string> Links { get; set; }
    }
}
