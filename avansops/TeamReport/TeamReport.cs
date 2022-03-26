using System;

namespace AvansOps {
	public class TeamReport 
	{
		public Project Project { get; }
		public Sprint Sprint { get; }

		public TeamReport(Project project, Sprint sprint)
        {
			Project = project;
			Sprint = sprint;
        }
	}
}
