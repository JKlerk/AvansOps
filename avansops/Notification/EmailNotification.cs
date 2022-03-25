using System;

namespace AvansOps {
	public class EmailNotification : INotificationStrategy  {
		
		private NotificationEmailProxy notificationEmailProxy;
		
		private void SendMail() {
			throw new System.NotImplementedException("Not implemented");
		}

		public override void Notify(ProjectMember projectMember, string message)
		{
			throw new NotImplementedException();
		}
	}

}
