namespace Common.Persistence.VideoCallManagement.TokBoxDto
{
    public class GetListOfRecordingsDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 50;
    }
}
