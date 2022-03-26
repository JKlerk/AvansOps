using AvansOps;

namespace AvansOps1.Notification {
	public class SlackAdapter {
		private readonly SlackService slackService;

		public SlackAdapter()
		{
			slackService = new SlackService();
		}
		
		public void SendSlackNotification(string message)
		{
			slackService.Send(message);
		}
	}

}
