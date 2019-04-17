namespace Common.Persistence.WebSocketManagement.WebSocketDto
{
    public class MessageDto
    {
        public string ClientId { get; set; } // if this is empty send message to all clients
        public string Message { get; set; }
        public string ChannelName { get; set; }
        public string EventName { get; set; }
        public string IdentificationNumber { get; set; } // can be used to perform operation on receiver side
    }
}
