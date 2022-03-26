using System;

namespace AvansOps {
	public class ThreadMessage {
		public int Id { get; }
		private string message;
		private DateTime dateTime;

		private ProjectMember projectMember;

		public ThreadMessage(string message, ProjectMember projectMember)
		{
			Id = 1;
			this.message = message;
			dateTime = DateTime.Now;
			this.projectMember = projectMember;
		}

		public string GetMessage() {
			return message;
		}

		public DateTime GetDateTime() {
			return dateTime;
		}
	}

}
