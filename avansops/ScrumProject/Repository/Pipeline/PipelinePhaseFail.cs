using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansOps
{
    class PipelinePhaseFail : PipelinePhase
    {
        protected override void Start()
        {
            base.Start();

            Console.WriteLine("Pipeline phase Fail has started");
        }

        protected override void Hook()
        {
            base.Hook();

            throw new Exception("Forced fail");
        }
    }
}
