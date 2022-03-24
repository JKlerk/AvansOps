using System;

namespace AvansOps {
	public class Commit {
		private string message;
		private DateTime dateTime;
		private ProjectMember projectMember;
		
		public Commit(ref DateTime dateTime, ref string message) {
			throw new System.NotImplementedException("Not implemented");
		}
		public string GetMessage() {
			return this.message;
		}
		public DateTime GetDateTime() {
			return this.dateTime;
		}

		

	}

}
