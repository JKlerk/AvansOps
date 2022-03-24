using System;

namespace AvansOps {
	public class Repository {
		public void Commit(ref Commit commit) {
			throw new System.NotImplementedException("Not implemented");
		}
		public Project GetProject() {
			throw new System.NotImplementedException("Not implemented");
		}
		public void CreatePipeline() {
			throw new System.NotImplementedException("Not implemented");
		}
		public void RunPipeLine() {
			throw new System.NotImplementedException("Not implemented");
		}
		public bool IsAPipelineRunning() {
			throw new System.NotImplementedException("Not implemented");
		}

		private Pipeline pipeline;
		private Commit commit;
		private Project project;

	}

}
