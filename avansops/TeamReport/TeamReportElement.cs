using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansOps
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
