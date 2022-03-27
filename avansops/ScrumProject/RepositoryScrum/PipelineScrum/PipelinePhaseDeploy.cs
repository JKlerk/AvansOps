using System;

namespace AvansOps.ScrumProject.RepositoryScrum.PipelineScrum {
	public class PipelinePhaseDeploy : PipelinePhase  {
		protected override void Finish()
		{
			base.Finish();

			Console.WriteLine("Pipeline phase Deploy has finished");
		}

		protected override void Start()
		{
			base.Start();

			Console.WriteLine("Pipeline phase Deploy has started");
		}
	}
}
