using System;

namespace AvansOps.ScrumProject.Repository.Pipeline {
	public class PipelinePhaseUtility : PipelinePhase  
	{
		protected override void Finish()
		{
			base.Finish();

			Console.WriteLine("Pipeline phase Utility has finished");
		}

		protected override void Start()
		{
			base.Start();

			Console.WriteLine("Pipeline phase Utility has started");
		}
	}
}
