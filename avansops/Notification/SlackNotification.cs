using System;

namespace AvansOps {
	public class SlackNotification : INotificationStrategy  {
		private SlackAdapter slackAdapter;

		private NotificationSlackProxy notificationSlackProxy;

		public SlackNotification(SlackAdapter slackAdapter)
		{
			this.slackAdapter = slackAdapter;
		}
		
		
		public void SendSlackNotification(string message)
		{
			slackAdapter.SendSlackNotification(message);
		}
	}

}
