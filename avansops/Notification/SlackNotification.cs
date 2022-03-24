using System;

namespace AvansOps {
	public class SlackNotification : INotificationStrategy  {
		public void SendSlackNotification(ref string message) {
			throw new System.NotImplementedException("Not implemented");
		}

		private SlackAdapter slackAdapter;

		private NotificationSlackProxy notificationSlackProxy;

	}

}
