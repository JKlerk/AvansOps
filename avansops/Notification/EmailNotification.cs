using System;
using AvansOps.ScrumProject;

namespace AvansOps.Notification
{
	public class EmailNotification : INotificationStrategy  {
		
		private void SendMail(string msg) {
			Console.Write(msg);
		}

		public override void Notify(ProjectMember projectMember, string message)
		{
			SendMail(message);
		}
	}

}
