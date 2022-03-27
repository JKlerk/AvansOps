using System.Collections.Generic;
using AvansOps.ScrumProject;
using AvansOps.ScrumProject.SprintScrum;

namespace AvansOps.TeamReportScrum {
	public class TeamReport 
	{
		public Project Project { get; }
		public Sprint Sprint { get; }
		public List<string> Lines { get; }
		public List<TeamReportElement> Elements { get; }

		public TeamReport(Project project, Sprint sprint)
        {
			Project = project;
			Sprint = sprint;
			Lines = new List<string>();
			Elements = new List<TeamReportElement>();
        }

		public TeamReportElement CreateElement()
        {
			TeamReportElement element = new TeamReportElement();
			Elements.Add(element);
			return element;
		}
	}
}