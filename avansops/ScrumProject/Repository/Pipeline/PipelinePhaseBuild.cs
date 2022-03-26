using System;

namespace AvansOps {
	public class PipelinePhaseBuild : IPipelinePhase  
	{
		protected override void Error()
		{
			base.Error();

			Console.WriteLine("Pipeline phase Build has encountered an error");
		}

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
