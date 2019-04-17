namespace Common.Persistence.VideoCallManagement.TokBoxDto
{
    public class SendSignalDto
    {
        public string SessionId { get; set; }
        public string DataToBeSent { get; set; }
        public string TypeOfData { get; set; }
        public string ReceiverConnectionId { get; set; } // if not specified signal will be sent to all clients
    }
}
