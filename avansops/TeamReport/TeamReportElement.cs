using System.Collections.Generic;

namespace AvansOps.TeamReport
{
    public class TeamReportElement
    {
        public List<string> TextLines { get; }
        public List<string> ImageUrls { get; }

        public TeamReportElement()
        {
            TextLines = new List<string>();
            ImageUrls = new List<string>();
        }
    }
}
