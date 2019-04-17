using System.Collections.Generic;

namespace Common.Persistence.PushNotificationManagement
{
    public class NotificationResponse
	{
		public NotificationResponse()
		{
			Errors = new List<string>();
		}
		public bool IsSuccess { get; set; } = false;
		public List<string> Errors { get; set; }
	}
}
