using System;

namespace AvansOps {
	public class PipelinePhasePackage : IPipelinePhase  
	{
		protected override void Error() 
		{
			base.Error();

			Console.WriteLine("Pipeline phase Package has encountered an error");
		}

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
