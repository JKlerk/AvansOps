using System;

namespace AvansOps {
	public abstract class IPipelinePhase {
		private IPipelinePhaseSubscriber[] subscribers;

		public void TemplateMethod() {
			throw new System.NotImplementedException("Not implemented");
		}
		protected abstract void StartPhase();
		protected void Hook() {
			throw new System.NotImplementedException("Not implemented");
		}
		protected abstract void Finish();
		protected abstract void Error();

		private Pipeline pipeline;
		private IPipelinePhaseSubscriber iPipelinePhaseSubscriber;

		private Pipeline[] pipelines;

	}

}
