using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansOps
{
    public class SprintRelease : Sprint
    {
        private Pipeline pipeline;

        public SprintRelease(int id, DateTime dateStart, DateTime dateEnd, Pipeline pipeline) : base(id, dateStart, dateEnd)
        {
            this.pipeline = pipeline;
        }

        protected override void TryFinish()
        {
            if (pipeline.IsFinished)
            {
                SprintState = SprintState.Finished;
            }
        }
    }
}
