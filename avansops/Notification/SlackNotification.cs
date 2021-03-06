using System;

namespace AvansOps {
	public class SlackNotification : INotificationStrategy  {
		private SlackAdapter slackAdapter;

		private NotificationSlackProxy notificationSlackProxy;

		public SlackNotification()
		{
			slackAdapter = new SlackAdapter();
		}
		
		
		public void SendSlackNotification(string message)
		{
			slackAdapter.SendSlackNotification(message);
		}

		public override void Notify(ProjectMember projectMember, string message)
		{
			slackAdapter.SendSlackNotification(message);
		}
	}

}
