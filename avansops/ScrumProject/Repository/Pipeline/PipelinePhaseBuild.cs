using System;

namespace AvansOps.ScrumProject.Repository.Pipeline {
	public class PipelinePhaseBuild : PipelinePhase  
	{
		protected override void Finish()
		{
			base.Finish();

			Console.WriteLine("Pipeline phase Build has finished");
		}

		protected override void Start()
		{
			base.Start();

			Console.WriteLine("Pipeline phase Build has started");
		}
	}
}
