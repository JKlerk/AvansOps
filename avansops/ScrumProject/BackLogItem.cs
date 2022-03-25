using System;

namespace AvansOps {
	public class BackLogItem {
		private int id;
		private string name;
		private string description;

		private ProjectMember? projectMember;
		private BackLogItemActivity[]? backLogItemActivity;
		private Thread[]? threads;
		private SprintBackLogItem[]? sprintBackLogItem;

		public BackLogItem(int id, string name, string description)
		{
			this.id = id;
			this.name = name;
			this.description = description;
		}

		public void CreateThread(ref ProjectMember projectMember, ref string name, ref object description) {
			throw new System.NotImplementedException("Not implemented");
		}
		public string GetName() {
			return this.name;
		}
		public string GetDescription() {
			return this.description;
		}
		public void CreateActivity(ref string name, ref string description) {
			throw new System.NotImplementedException("Not implemented");
		}
		public bool IsActivitiesDone() {
			throw new System.NotImplementedException("Not implemented");
		}
		public void SetName(ref string name) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void SetDescription(ref string description) {
			throw new System.NotImplementedException("Not implemented");
		}
		private bool IsBoundToSprint() {
			throw new System.NotImplementedException("Not implemented");
		}
		public bool IsDone() {
			throw new System.NotImplementedException("Not implemented");
		}
		public void SetSprintBackLogItem(ref SprintBackLogItem sprintBackLogItem) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void SetToDone() {
			throw new System.NotImplementedException("Not implemented");
		}

	}

}
