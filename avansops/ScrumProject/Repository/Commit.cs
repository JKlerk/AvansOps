using System;

namespace AvansOps {
	public class Commit {
		private readonly string message;
		private readonly DateTime dateTime;
		private readonly ProjectMember projectMember;
		
		public Commit(string message, ProjectMember member) {
			dateTime = DateTime.Now;
			projectMember = member;
			this.message = message;
		}
		public string GetMessage() {
			return message;
		}
		public DateTime GetDateTime() {
			return dateTime;
		}

		public ProjectMember GetProjectMember()
		{
			return projectMember;
		}

	}

}
