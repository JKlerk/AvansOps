using System;

namespace AvansOps {
	public class TeamReportGenerator 
	{
		private IReportExportStrategy iReportExportStrategy;

		public void GenerateReport(Project project, Sprint sprint) 
		{
			TeamReport report = new TeamReport(project, sprint);
			ExportReport(report);
		}

		public void ExportReport(TeamReport report) 
		{
			iReportExportStrategy.ExportReport(report);
		}
	}
}
