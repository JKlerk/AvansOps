using System;
using System.Collections.Generic;

namespace AvansOps {
	public class Thread {
		private int id;
		private string name;
		private string description;
		private ProjectMember creator;
		private List<ThreadMessage> threadMessages;
		private BackLogItem backLogItem;

		public Thread(int id, string name, string description, ProjectMember creator)
		{
			this.id = id;
			this.name = name;
			this.description = description;
			this.creator = creator;
		}

		public void CreateMessage(string message, ProjectMember projectMember) {
			threadMessages.Add(new ThreadMessage(message, projectMember));
		}
		public string GetName() {
			return name;
		}
		public string GetDescription() {
			return description;
		}
	}

}
