using System;
using System.Collections.Generic;
using AvansOps.Notification;

namespace AvansOps.ScrumProject {
	public class Thread {
		private int id;
		private readonly string name;
		private readonly string description;
		private readonly List<ThreadMessage> threadMessages;
		private ProjectMember creator;
		public bool BackLogItemIsDone;

		public Thread(int id, string name, string description, ProjectMember creator)
		{
			this.id = id;
			this.name = name;
			this.description = description;
			this.creator = creator;
			threadMessages = new List<ThreadMessage>();
			BackLogItemIsDone = false;
		}

		public void CreateMessage(string message, ProjectMember projectMember)
		{
			if (BackLogItemIsDone) throw new Exception("Backlog item is done, cannot add message");
			NotificationManager.Notify(creator, "New message has been placed by " + projectMember.User.FirstName);
			threadMessages.Add(new ThreadMessage(message, projectMember));
		}
		public string GetName() {
			return name;
		}
		public string GetDescription() {
			return description;
		}

		public List<ThreadMessage> GetThreadMessages()
		{
			return threadMessages;
		}
	}

}
