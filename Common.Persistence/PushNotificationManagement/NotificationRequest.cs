namespace Common.Persistence.PushNotificationManagement
{
    public class NotificationRequest
	{
		public string pns { get; set; }
		public string message { get; set; }
		public string to_tag { get; set; }
		public string Id { get; set; }
		public string NotifcationType { get; set; }
	}
}
