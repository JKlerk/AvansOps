using System;

namespace AvansOps {
	public class Thread {
		private int id;
		private string name;
		private string description;
		private ProjectMember creator;

		public void CreateMessage(ref string message, ref ProjectMember projectMember) {
			throw new System.NotImplementedException("Not implemented");
		}
		public string GetName() {
			return this.name;
		}
		public string GetDescription() {
			return this.description;
		}

		private ThreadMessage threadMessage;

		private BackLogItem[] backLogItems;

	}

}
