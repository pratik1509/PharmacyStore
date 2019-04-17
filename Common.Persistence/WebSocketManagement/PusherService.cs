using System.Threading.Tasks;
using Common.Persistence.WebSocketManagement.WebSocketDto;
using PusherServer;

namespace Common.Persistence.WebSocketManagement
{
    public class PusherService : IWebSocketService
    {
        private readonly Pusher _pusher;
        
        public PusherService(PusherSettings pusherConfiguration)
        {
            var _pusherOptions = new PusherOptions
            {
                Cluster = pusherConfiguration.Cluster,
                Encrypted = pusherConfiguration.IsEncrypted
            };

            _pusher = new Pusher(
                pusherConfiguration.AppId,
                pusherConfiguration.Key,
                pusherConfiguration.Secret,
                _pusherOptions
            );
        }
        public async Task SendMessage(MessageDto message)
        {
            // if client id is not empty, appending it to channel name, so we can send message to a particular client
            // if client id is empty, send message to all connected clients
            var channelName = message.ChannelName + (string.IsNullOrWhiteSpace(message.ClientId) ? "" : "-" + message.ClientId);

            var result = await _pusher.TriggerAsync(
              channelName,
              message.EventName,
              new { message = message.Message, id = message.IdentificationNumber });
        }
    }
}
