using System;

namespace AvansOps {
	public class BackLogItemActivity {
		private int id;
		private string name;
		private string description;

		private ProjectMember projectMember;
		private BackLogItem[] backLogItems;
		
		public BackLogItem GetBackLogItem() {
			throw new System.NotImplementedException("Not implemented");
		}
		public string GetName() {
			return this.name;
		}
		public string GetDescription() {
			return this.description;
		}
	}

}
