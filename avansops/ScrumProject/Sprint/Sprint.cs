using System;

namespace AvansOps {
	public class Sprint {
		private int id;
		private DateTime dateStart;
		private DateTime dateEnd;

		public void Cancel() {
			throw new System.NotImplementedException("Not implemented");
		}
		public ProjectMember[] GetProjectMembers() {
			throw new System.NotImplementedException("Not implemented");
		}

		private SprintType sprintType;
		private SprintState sprintState;
		private SprintBackLogItem sprintBackLogItem;

		private Project[] projects;
		private ProjectMember projectMember;

	}

}
