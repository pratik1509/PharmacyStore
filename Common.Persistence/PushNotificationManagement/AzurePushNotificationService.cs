using Microsoft.Azure.NotificationHubs;
using Microsoft.Azure.NotificationHubs.Messaging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Common.Persistence.PushNotificationManagement
{
	public class AzurePushNotificationService : IPushNotificationService
	{
		private readonly NotificationHubClient _hub;

		public AzurePushNotificationService(string connectionString, string notificationHubPath)
		{
			_hub = NotificationHubClient.CreateClientFromConnectionString(connectionString, notificationHubPath);
		}

		public async Task<RegistrationResponse> CreateRegistration(string handle)
		{
			RegistrationResponse response = new RegistrationResponse();

			string newRegistrationId = null;
			// make sure there are no existing registrations for this push handle (used for iOS and Android)
			if (handle != null)
			{
				var registrations = await _hub.GetRegistrationsByChannelAsync(handle, 100);

				foreach (RegistrationDescription registration in registrations)
				{
					if (newRegistrationId == null)
					{
						newRegistrationId = registration.RegistrationId;
					}
					else
					{
						await _hub.DeleteRegistrationAsync(registration);
					}
				}
			}

			if (newRegistrationId == null)
				newRegistrationId = await _hub.CreateRegistrationIdAsync();

			response.RegistrationId = newRegistrationId;
			response.IsSuccess = true;
			return response;
		}

		public async Task<RegistrationResponse> DeviceRegistration(
			string registrationId, string handle, string platform, string userName)
		{
			RegistrationResponse response = new RegistrationResponse();

			RegistrationDescription registration = null;
			switch (platform)
			{
				case "mpns":
					registration = new MpnsRegistrationDescription(handle);
					break;
				case "wns":
					registration = new WindowsRegistrationDescription(handle);
					break;
				case "apns":
					registration = new AppleRegistrationDescription(handle);
					break;
				case "gcm":
					registration = new GcmRegistrationDescription(handle);
					break;
				default:
					response.Errors.Add("No Platform");
					response.IsSuccess = false;
					return response;
			}

			registration.RegistrationId = registrationId;

			// add check if user is allowed to add these tags
			registration.Tags = new HashSet<string>();
			registration.Tags.Add("username:" + userName);
			//registration.Tags = new HashSet<string>(request.Tags)
			//{
			//	"username:" + username
			//};

			try
			{
				await _hub.CreateOrUpdateRegistrationAsync(registration);
				response.RegistrationId = registrationId;
			}
			catch (MessagingException e)
			{
				var webex = e.InnerException as WebException;
				if (webex.Status == WebExceptionStatus.ProtocolError)
				{
					var webresponse = (HttpWebResponse)webex.Response;
					if (webresponse.StatusCode == HttpStatusCode.Gone)
					{
						response.Errors.Add("the requested resource is no longer available");

					}
					else
					{
						response.Errors.Add("the requested resource is no longer available");
					}
					response.IsSuccess = false;
					return response;
				}
				throw e;
			}

			response.IsSuccess = true;
			return response;
		}

		public async Task<RegistrationResponse> DeleteRegistration(string registrationId)
		{
			RegistrationResponse response = new RegistrationResponse();
			await _hub.DeleteRegistrationAsync(registrationId);
			response.RegistrationId = registrationId;
			response.IsSuccess = true;
			return response;
		}

		public async Task<NotificationResponse> PushNotification(NotificationRequest request)
		{
			try
			{


				NotificationResponse response = new NotificationResponse();
				var user = string.Empty;
				var message = request.message;
				var userTag = new string[2];
				userTag[0] = "username:" + request.to_tag;
				userTag[1] = "from:" + user;

				NotificationOutcome outcome = null;

				request.pns = "gcm";

				switch (request.pns.ToLower())
				{
					case "wns":
						// Windows 8.1 / Windows Phone 8.1
						var toast = @"<toast><visual><binding template=""ToastText01""><text id=""1"">" +
									"From " + user + ": " + message + "</text></binding></visual></toast>";
						outcome = await _hub.SendWindowsNativeNotificationAsync(toast, userTag);

						// Windows 10 specific Action Center support
						toast = @"<toast><visual><binding template=""ToastGeneric""><text id=""1"">" +
									"From " + user + ": " + message + "</text></binding></visual></toast>";
						outcome = await _hub.SendWindowsNativeNotificationAsync(toast, userTag);

						// Additionally sending Windows Phone Notification MPNS
						//toast = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
						//        "<wp:Notification xmlns:wp=\"WPNotification\"><wp:Toast><wp:Text1>" + 
						//            "From " + user + ": " + message + 
						//            "</wp:Text1></wp:Toast></wp:Notification>";
						//outcome = await Notifications.Instance.Hub.SendMpnsNativeNotificationAsync(toast, userTag);

						break;
					case "apns":
						// iOS
						var alert = "{\"aps\":{\"alert\":\"" + "From " + user + ": " + message + "\"}}";
						outcome = await _hub.SendAppleNativeNotificationAsync(alert, userTag);
						break;
					case "gcm":
						// Android
						var notif = "{ \"data\" : {\"message\":\"" + message + "\",\"id\":\"" + request.Id + "\",\"type\":\"" + request.NotifcationType + "\"}}";
						outcome = await _hub.SendGcmNativeNotificationAsync(notif, userTag);
						break;
				}

				if (outcome != null)
				{
					if (!((outcome.State == NotificationOutcomeState.Abandoned) ||
						(outcome.State == NotificationOutcomeState.Unknown)))
					{
						return new NotificationResponse { IsSuccess = true };
					}
				}

			}
			catch (System.Exception)
			{
				//TODO: remove try catch
			}
			return new NotificationResponse { IsSuccess = false };
		}
	}
}
