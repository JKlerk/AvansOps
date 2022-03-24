using System;

namespace AvansOps {
	public class Pipeline : IPipelinePhaseSubscriber  {
		private bool isRunning;
		private int indexCurrentPhase;

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

		private IPipelinePhase iPipelinePhase;
		private Repository repository;
		private NotificationManager notificationManager;

		private Repository[] repositorys;

	}

}
