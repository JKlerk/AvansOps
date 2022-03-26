using System.Collections.Generic;
using AvansOps;

namespace AvansOps1.Notification {
	public class NotificationSlackProxy : INotificationStrategy
	{
		public List<string> Messages { get; }
		private SlackNotification slackNotification;

		public NotificationSlackProxy()
		{
			slackNotification = new SlackNotification();
			Messages = new List<string>();
		}

		private void LogNotification(string message) {
			Messages.Add(message);
		}

		public override void Notify(ProjectMember projectMember, string message)
		{
			LogNotification(message);
			slackNotification.Notify(projectMember, message);
		}
	}

}
