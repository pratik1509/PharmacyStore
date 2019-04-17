using System.Collections.Generic;

namespace Common.Persistence.PushNotificationManagement
{
    public class RegistrationResponse
	{
		public RegistrationResponse()
		{
			Errors = new List<string>();
		}
		public bool IsSuccess { get; set; }
		public string RegistrationId { get; set; }
		public List<string> Errors { get; set; }
	}
}
