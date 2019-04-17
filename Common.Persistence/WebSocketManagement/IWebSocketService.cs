using Common.Persistence.WebSocketManagement.WebSocketDto;
using System.Threading.Tasks;

namespace Common.Persistence.WebSocketManagement
{
    public interface IWebSocketService
    {
        Task SendMessage(MessageDto message);
    }
}
