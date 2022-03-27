using System;

namespace AvansOps.ScrumProject.Repository.Pipeline {
	public class PipelinePhaseAnalyse : PipelinePhase  {
		protected override void Finish()
		{
			base.Finish();

			Console.WriteLine("Pipeline phase Analyse has finished");
		}

		protected override void Start()
		{
			base.Start();

			Console.WriteLine("Pipeline phase Analyse has started");
		}
	}
}
