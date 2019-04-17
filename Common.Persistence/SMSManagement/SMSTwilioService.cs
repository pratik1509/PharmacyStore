using Common.Persistence.Abstractions;
using Common.Persistence.LogManagement;
using Common.Persistence.Models;
using Common.Persistence.SMSManagement.Abstraction;
using Common.Persistence.SMSManagement.Model;
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Common.Persistence.SMSManagement
{
    public class SMSTwilioService : ISMSService
    {
        private readonly string _accountSID;
        private readonly string _authenticationToken;
        private readonly string _smsFromPhoneNumber;
        private readonly ITokenHelperService _tokenHelperService;
        private readonly ILoggerService _loggerService;
        private IList<Token> _commonTokens;

        public SMSTwilioService(string accountSId,
            string authenticationToken,
            string smsFromPhoneNumber,
            ITokenHelperService tokenHelperService,
            ILoggerService loggerService,
            IList<Token> commonTokens)
        {
            _accountSID = accountSId;
            _authenticationToken = authenticationToken;
            _smsFromPhoneNumber = smsFromPhoneNumber;
            _tokenHelperService = tokenHelperService;
            _loggerService = loggerService;
            _commonTokens = commonTokens;
        }

        public bool SendSMS(SMSDto dto)
        {
            try
            {
                _commonTokens = _commonTokens ?? new List<Token>();

                #region token replacement
                //replcaing sms text with default tokens
                dto.SMSText = _tokenHelperService.Replace(dto.SMSText, _commonTokens, true);
                //replacing sms text with sms specific tokens
                dto.SMSText = _tokenHelperService.Replace(dto.SMSText, dto.SMSSpecificTokens, true);
                #endregion

                string accountSid = _accountSID;
                string authToken = _authenticationToken;
                TwilioClient.Init(accountSid, authToken);
                var to = new PhoneNumber(dto.SMSToPhoneNumber);
                var message = MessageResource.Create(
                    to,
                    from: new PhoneNumber(_smsFromPhoneNumber), //  From number, must be an SMS-enabled Twilio number ( This will send sms from ur "To" numbers ).
                    body: dto.SMSText);

                return true;
            }
            catch (Exception ex)
            {
                _loggerService.Error(ex, ex.Message, null);
                return true;
            }
        }
    }
}
