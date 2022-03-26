using System;
using System.Collections.Generic;

namespace AvansOps {
	public class Repository {
		private List<Pipeline> pipelines;
		private List<Commit> commits;
		private Project project;


		public Repository(Project project)
		{
			this.project = project;
			pipelines = new List<Pipeline>();
			commits = new List<Commit>();

		}

		public void Commit(Commit commit) {
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
	}

}
