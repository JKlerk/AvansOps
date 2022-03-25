using System;

namespace AvansOps {
	public class ThreadMessage {
		private int id;
		private string message;
		private DateTime dateTime;

		private ProjectMember projectMember;
		private Thread[] threads;
		
		public string GetMessage() {
			return this.message;
		}
		public DateTime GetDateTime() {
			return this.dateTime;
		}
	}

}
