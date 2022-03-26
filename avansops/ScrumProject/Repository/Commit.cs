using System;

namespace AvansOps {
	public class Commit {
		public string Message { get; }
		public DateTime DateTime { get; }
		public ProjectMember ProjectMember { get; }
		
		public Commit(DateTime dateTime, string message, ProjectMember projectMember) 
		{
			DateTime = dateTime;
			Message = message;
			ProjectMember = projectMember;
		}
	}
}
