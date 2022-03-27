using System;

namespace AvansOps {
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
