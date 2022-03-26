using System;

namespace AvansOps {
    public class ExportReportPNG : IReportExportStrategy
    {
        public void ExportReport(TeamReport report)
        {
            Console.Write(report.Project.Name + " report exported to PNG");
        }
    }

}
