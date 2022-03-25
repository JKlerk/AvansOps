using System;

namespace AvansOps {
	public class SlackAdapter {
		
		private readonly SlackService slackService;

		private SlackNotification slackNotification;

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
