using System;
using System.Collections.Generic;

namespace AvansOps {
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
