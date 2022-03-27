using AvansOps.ScrumProject;
using AvansOps.ScrumProject.Sprint;

namespace AvansOps.TeamReport 
{
	public static class TeamReportGenerator 
	{
		public static TeamReport GenerateReport(Project project, Sprint sprint) 
		{
			TeamReport report = new TeamReport(project, sprint);

			AddHeader(report);
			AddBody(report);
			AddFooter(report);

			return report;
		}

		private static TeamReportElement AddHeader(TeamReport report)
        {
			TeamReportElement header = report.CreateElement();
			header.TextLines.Add(report.Project.Name);
			header.TextLines.Add(report.Project.Description);

			int sprintNumber = report.Project.Sprints.IndexOf(report.Sprint);

			header.TextLines.Add("Sprint " + sprintNumber.ToString());
			header.TextLines.Add(report.Sprint.DateStart + " - " + report.Sprint.DateEnd);
			header.TextLines.Add("--------------------------");

			return header;
		}

		private static TeamReportElement AddBody(TeamReport report)
		{
			TeamReportElement body = report.CreateElement();
			body.TextLines.Add("BODY");
			body.TextLines.Add("--------------------------");

			return body;
		}

		private static TeamReportElement AddFooter(TeamReport report)
		{
			TeamReportElement footer = report.CreateElement();
			footer.TextLines.Add("FOOTER");
			footer.TextLines.Add("--------------------------");

			return footer;
		}

		public static void ExportReport(TeamReport report, IReportExportStrategy reportExportStrategy) 
		{
			reportExportStrategy.ExportReport(report);
		}
	}
}
