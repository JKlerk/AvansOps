using System;

namespace AvansOps.ScrumProject.RepositoryScrum.PipelineScrum
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
