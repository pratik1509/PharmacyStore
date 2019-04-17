using Common.Persistence.Abstractions;
using Common.Persistence.LogManagement;
using Common.Persistence.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Persistence.EmailManagement
{
    public class SendGridEmailService : IEmailService
    {
        private string _apikey { get; set; }
        private readonly ITokenHelperService _tokenHelperService;
        private readonly ILoggerService _loggerService;
        private readonly string _fromEmailId;
        private readonly string _senderName;
        private IList<Token> _commonTokens;
        
        public SendGridEmailService(string apikey, 
            string fromEmailid, 
            string sendername,
            IList<Token> commonTokens,
            ITokenHelperService tokenHelperService, 
            ILoggerService loggerService)
        {
            _apikey = apikey;
            _fromEmailId = fromEmailid;
            _tokenHelperService = tokenHelperService;
            _senderName = sendername;
            _commonTokens = commonTokens;
            _loggerService = loggerService;
        }
        public async Task<bool> SendEmail(EmailDto emailDto)
        {
            try
            {
                var client = new SendGridClient(_apikey);
                var from = new EmailAddress(_fromEmailId, _senderName);
                var to = new EmailAddress(emailDto.ToEmailAddress, emailDto.ToName);

                var substitutions = new List<Dictionary<string, string>> { };

                _commonTokens = _commonTokens ?? new List<Token>();

                #region token replacement for subject and body

                //replacing common tokens in subject
                emailDto.Subject = 
                    _tokenHelperService.Replace(emailDto.Subject, _commonTokens, true);
                //replacing email specific tokens in subject
                emailDto.Subject =
                    _tokenHelperService.Replace(emailDto.Subject, emailDto.EmailSpecificTokens, true);
                
                //replacing common tokens in body
                emailDto.Body = _tokenHelperService.Replace(emailDto.Body, _commonTokens, true);
                //replacing email specific tokens in body
                emailDto.Body = _tokenHelperService.Replace(emailDto.Body, emailDto.EmailSpecificTokens, true);

                #endregion

                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from,
                        new List<EmailAddress> { to }, emailDto.Subject, string.Empty,emailDto.Body);

                var response = await client.SendEmailAsync(msg);
                return response.StatusCode == System.Net.HttpStatusCode.Accepted;
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                {
                    // Handle the custom exception.
                    await _loggerService
                        .Error(e, "Aggregate exception thrown - " + e.Message, e.StackTrace);
                }
            }
            catch (Exception ex)
            {
                await _loggerService.Error(ex, ex.Message, null);
            }
            return false;
        }
    }
}
