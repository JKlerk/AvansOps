using System;

namespace AvansOps {
	public class PipelinePhaseDeploy : IPipelinePhase  {
		protected override void Error()
		{
			base.Error();

			Console.WriteLine("Pipeline phase Deploy has encountered an error");
		}

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
