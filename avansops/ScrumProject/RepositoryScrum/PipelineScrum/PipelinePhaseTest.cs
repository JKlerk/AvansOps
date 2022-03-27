using System;

namespace AvansOps.ScrumProject.RepositoryScrum.PipelineScrum {
	public class PipelinePhaseTest : PipelinePhase  
	{
		protected override void Finish()
		{
			base.Finish();

			Console.WriteLine("Pipeline phase Test has finished");
		}

		protected override void Start()
		{
			base.Start();

			Console.WriteLine("Pipeline phase Test has started");
		}
	}
}
