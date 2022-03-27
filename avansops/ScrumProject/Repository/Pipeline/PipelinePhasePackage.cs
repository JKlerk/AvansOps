using System;

namespace AvansOps.ScrumProject.Repository.Pipeline {
	public class PipelinePhasePackage : PipelinePhase  
	{
		protected override void Finish() 
		{
			base.Finish();

			Console.WriteLine("Pipeline phase Package has finished");
		}

		protected override void Start() 
		{
			base.Start();

			Console.WriteLine("Pipeline phase Package has started");
		}
	}
}
