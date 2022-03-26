using System;

namespace AvansOps {
	public class BackLogItemActivity {
		private int id;
		private string name;
		private string description;

		private ProjectMember projectMember;
		private BackLogItem backLogItem;

		public BackLogItemActivity(int id, string name, string description, ProjectMember projectMember, BackLogItem backLogItem)
		{
			this.id = id;
			this.name = name;
			this.description = description;
			this.projectMember = projectMember;
			this.backLogItem = backLogItem;
		}

		public BackLogItem GetBackLogItem()
		{
			return backLogItem;
		}
		public string GetName() {
			return name;
		}
		public string GetDescription() {
			return description;
		}
	}

}
