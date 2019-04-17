using System.Threading.Tasks;

namespace Common.Persistence.EmailManagement
{
    public interface IEmailService
    {
        /// <summary>
        /// send email
        /// </summary>
        /// <param name="emailDto"></param>
        /// <returns></returns>
        Task<bool> SendEmail(EmailDto emailDto);
    }
}
