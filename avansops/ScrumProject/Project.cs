using System;

namespace AvansOps {
	public class Project {
		private int id;
		private string name;
		private string description;
		private BackLogItem backLogItem;
		private Repository repository;
		private Sprint sprint;
		private ProjectMember projectMember;
		private SprintPhase sprintPhase;

		public Project(int id, string name, string description, BackLogItem backLogItem, Repository repository, Sprint sprint, ProjectMember projectMember, SprintPhase sprintPhase)
		{
			this.id = id;
			this.name = name;
			this.description = description;
			this.backLogItem = backLogItem;
			this.repository = repository;
			this.sprint = sprint;
			this.projectMember = projectMember;
			this.sprintPhase = sprintPhase;
		}

		public void NotifyRole(ref Role role) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void AddBackLogItem(ref BackLogItem backLogItem) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void AddSprint() {
			throw new System.NotImplementedException("Not implemented");
		}
		public void AddBackLogItemToSprintBackLog(ref BackLogItem backLogItem, ref Sprint sprint) {
			throw new System.NotImplementedException("Not implemented");
		}
		private void CreateSprintBackLogItem(ref BackLogItem backLogItem) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void AddPhase(ref SprintPhase phase) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void MoveSprintBackLogItemToPhase(ref ProjectMember projectMember, ref SprintBackLogItem sprintBackLogItem, ref SprintPhase phase) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void UploadReviewDoc(ref Sprint sprint) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void StartPipelineCurrentSprint() {
			throw new System.NotImplementedException("Not implemented");
		}
		public void FinishCurrentSprint() {
			throw new System.NotImplementedException("Not implemented");
		}
	}

}
