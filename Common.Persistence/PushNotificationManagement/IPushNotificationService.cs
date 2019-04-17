using System.Threading.Tasks;

namespace Common.Persistence.PushNotificationManagement
{
    public interface IPushNotificationService
	{
		Task<RegistrationResponse> CreateRegistration(string handle);
		Task<RegistrationResponse> DeviceRegistration(string registrationId, string handle, string platform, string userName);
		Task<RegistrationResponse> DeleteRegistration(string registrationId);
		Task<NotificationResponse> PushNotification(NotificationRequest request);
	}
}
