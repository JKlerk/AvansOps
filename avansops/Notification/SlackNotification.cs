using AvansOps;
using AvansOps.Notification;

namespace AvansOps
{
	public class SlackNotification : INotificationStrategy  {
		private SlackAdapter slackAdapter;
		
		public SlackNotification()
		{
			slackAdapter = new SlackAdapter();
		}

		public override void Notify(ProjectMember projectMember, string message)
		{
			slackAdapter.SendSlackNotification(message);
		}
	}

}
