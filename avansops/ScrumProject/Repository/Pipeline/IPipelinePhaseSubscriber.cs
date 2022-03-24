using System;

namespace AvansOps {
	public abstract class IPipelinePhaseSubscriber {
		public void Finish() {
			throw new System.NotImplementedException("Not implemented");
		}
		public void Error(ref string message) {
			throw new System.NotImplementedException("Not implemented");
		}

		private IPipelinePhase[] iPipelinePhases;

	}

}
