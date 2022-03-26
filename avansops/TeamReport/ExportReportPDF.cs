using System;

namespace AvansOps 
{
    public class ExportReportPDF : IReportExportStrategy
    {
        public void ExportReport(TeamReport report)
        {
            Console.WriteLine(report.Project.Name + " report exported to PDF");
        }
    }
}
