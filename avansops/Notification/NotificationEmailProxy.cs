using System;

namespace AvansOps {
	public class NotificationEmailProxy : INotificationStrategy  {
		private EmailNotification emailNotification;
		private void LogNotification() {
			throw new System.NotImplementedException("Not implemented");
		}

		public override void Notify(ProjectMember projectMember, string message)
		{
			throw new NotImplementedException();
		}
	}

}
