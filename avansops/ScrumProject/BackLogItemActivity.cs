namespace AvansOps.ScrumProject {
	public class BackLogItemActivity {
		private int id;
		private string name;
		private string description;
		private bool isDone;
		
		private ProjectMember projectMember;
		

		public BackLogItemActivity(int id, string name, string description, ProjectMember projectMember)
		{
			this.id = id;
			this.name = name;
			this.description = description;
			this.projectMember = projectMember;
		}
		
		public string GetName() {
			return name;
		}
		public string GetDescription() {
			return description;
		}

		public bool IsAcitvityDone()
		{
			return isDone;
		}

		public void SetActivityDone()
		{
			isDone = true;
		}

		public ProjectMember GetProjectMember()
		{
			return projectMember;
		}
	}

}
