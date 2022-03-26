using System;

namespace AvansOps {
	public class PipelinePhaseTest : IPipelinePhase  {
		protected override void Error()
		{
			base.Error();

			Console.WriteLine("Pipeline phase Test has encountered an error");
		}

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
