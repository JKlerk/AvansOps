using System;

namespace AvansOps {
	public class Pipeline : IPipelinePhaseSubscriber  {
		
		private IPipelinePhase iPipelinePhase;
		private Repository repository;

		private bool isRunning;
		private int indexCurrentPhase;

		public Pipeline(Repository repository)
		{
			this.repository = repository;
		}

		public void RunPipeline() {
			throw new System.NotImplementedException("Not implemented");
		}
		private void StartPhase(ref int index) {
			throw new System.NotImplementedException("Not implemented");
		}
		private void AdvancePhase() {
			throw new System.NotImplementedException("Not implemented");
		}
		private void FinishPipeline() {
			throw new System.NotImplementedException("Not implemented");
		}
		public bool IsRunning() {
			throw new System.NotImplementedException("Not implemented");
		}

	}

}
