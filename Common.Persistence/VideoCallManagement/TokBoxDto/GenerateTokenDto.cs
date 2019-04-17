using OpenTokCore;

namespace Common.Persistence.VideoCallManagement.TokBoxDto
{
    public class GenerateTokenDto
    {
        public string SessionId { get; set; }
        public Role Role { get; set; }
        public int ExpireTokenInDays { get; set; }
        public string Data { get; set; }
    }
}
