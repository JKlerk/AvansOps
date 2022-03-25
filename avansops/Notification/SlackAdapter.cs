using System;

namespace AvansOps {
	public class SlackAdapter {
		
		private readonly SlackService slackService;

		private SlackNotification slackNotification;

		public SlackAdapter(SlackService slackService)
		{
			this.slackService = slackService;
		}
		
		
		public void SendSlackNotification(string message)
		{
			slackService.Send(message);
		}
	}

}
