using System;
using System.Collections.Generic;

namespace AvansOps 
{
	public class Repository 
	{
		private Pipeline pipeline;
		private List<Commit> commits;

		public Project Project { get; }

		public Repository(Project project)
		{
			Project = project;
			commits = new List<Commit>();
			pipeline = PipelineFactory.CreatePipeline(this);
		}
		public void Commit(Commit commit) 
		{
			commits.Add(commit);
		}

		public void RunPipeLine() 
		{
			pipeline.Run();
		}

		public bool IsPipelineRunning() 
		{
			return pipeline.IsRunning;
		}
	}
}
