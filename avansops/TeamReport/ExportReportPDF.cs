using System;

namespace AvansOps.TeamReport 
{
    public class ExportReportPDF : IReportExportStrategy
    {
        public void ExportReport(TeamReport report)
        {
            foreach(TeamReportElement element in report.Elements)
            {
                Console.WriteLine(element.TextLines);
            }

            Console.Write(report.Project.Name + " report exported to PNG");
        }
    }
}
