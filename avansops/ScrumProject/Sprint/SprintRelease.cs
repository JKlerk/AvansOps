using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansOps
{
    public class SprintRelease : Sprint
    {
        public SprintRelease(int id, DateTime dateStart, DateTime dateEnd) : base(id, dateStart, dateEnd)
        { }

        public void FinishPipeline()
        {
            Finish();
        }
    }
}
