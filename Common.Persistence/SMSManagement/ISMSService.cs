using Common.Persistence.SMSManagement.Model;

namespace Common.Persistence.SMSManagement.Abstraction
{
    public interface ISMSService
    {
        bool SendSMS(SMSDto dto);
    }
}
