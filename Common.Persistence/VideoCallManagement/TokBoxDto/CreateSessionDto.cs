using OpenTokCore;

namespace Common.Persistence.VideoCallManagement.TokBoxDto
{
    public class CreateSessionDto
    {
        public string Location { get; set; }
        public MediaMode MediaMode { get; set; }
        public ArchiveMode ArchiveMode { get; set; }
    }
}
