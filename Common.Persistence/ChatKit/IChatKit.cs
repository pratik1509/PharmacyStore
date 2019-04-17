using Common.Persistence.ChatKit.ChatKitDto;
using System.Threading.Tasks;

namespace Common.Persistence.ChatKit
{
    public interface IChatKit
    {
        Task<UserDto> CreateUser(CreateUserDto createUserDto);
    }
}
