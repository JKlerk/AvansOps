using System;
using AvansOps;

namespace AvansOps1.Notification {
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
