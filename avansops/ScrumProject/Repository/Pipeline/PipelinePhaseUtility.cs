using System;

namespace AvansOps {
	public class PipelinePhaseUtility : IPipelinePhase  {
		protected override void Error()
		{
			base.Error();

			Console.WriteLine("Pipeline phase Utility has encountered an error");
		}

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
