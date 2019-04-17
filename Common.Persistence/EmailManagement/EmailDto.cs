using Common.Persistence.Models;
using System.Collections.Generic;

namespace Common.Persistence.EmailManagement
{
    public class EmailDto
    {
        /// <summary>
        /// subject of email
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Body of email
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Email address of recipient 
        /// </summary>
        public string ToEmailAddress{ get; set; }
        /// <summary>
        /// Name of recipient
        /// </summary>
        public string ToName { get; set; }
        /// <summary>
        /// Email specific tokens
        /// </summary>
        public List<Token> EmailSpecificTokens { get; set; }
    }
}
