using Common.Persistence.ChatKit.ChatKitDto;
using Common.Persistence.ExternalAPICallManagement;
using Common.Persistence.ExternalAPICallManagement.APIDto;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Common.Persistence.ChatKit
{
    public class ChatKit : IChatKit
    {
        private readonly IApiCallWrapperService _apiCallWrapperService;
        private readonly ChatKitConfig _chatKitConfig;

        public ChatKit(IApiCallWrapperService apiCallWrapperService, ChatKitConfig chatKitConfig)
        {
            _apiCallWrapperService = apiCallWrapperService;
            _chatKitConfig = chatKitConfig;
        }

        public async Task<UserDto> CreateUser(CreateUserDto createUserDto)
        {
            //Dictionary<string, string> setheader = new Dictionary<string, string>
            //{
            //    { "Accept", new string("application/json") },
            //    { "Authorization", new string("Bearer " + _chatKitConfig.) }
            //};

            //var response = await _apiCallWrapperService.ExecuteTaskAsync<CreateUserDto, UserDto>(new Request<CreateUserDto>
            //{
            //    BaseUrl = string.Format(_chatKitConfig.BaseUrl, _chatKitConfig.InstanceId),
            //    Url = _chatKitConfig.CreateUserUrl,
            //    Method = WrapperMethod.POST,
            //    Headers = 
            //});

            return null;
        }
    }
}
