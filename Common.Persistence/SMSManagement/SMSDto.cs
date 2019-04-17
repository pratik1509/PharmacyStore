using Common.Persistence.Models;
using System.Collections.Generic;

namespace Common.Persistence.SMSManagement.Model
{
    public class SMSDto
    {
        public string SMSText { get; set; }
        public string SMSToPhoneNumber { get; set; }
        public IList<Token> SMSSpecificTokens { get; set; }
    }
}
