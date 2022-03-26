using System;
using System.Collections.Generic;
using AvansOps;

namespace AvansOps1.Notification {
	public class NotificationEmailProxy : INotificationStrategy  {
		
		private EmailNotification emailNotification;
		public List<string> Messages { get; }

		public NotificationEmailProxy()
		{
			emailNotification = new EmailNotification();
			Messages = new List<string>();
		}

		private void LogNotification(string message) {
			Messages.Add(message);
		}

		public override void Notify(ProjectMember projectMember, string message)
		{
			LogNotification(message);
			emailNotification.Notify(projectMember, message);
		}
	}

}
