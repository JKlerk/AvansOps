using System;
using System.Collections.Generic;
using System.Linq;

namespace AvansOps 
{
	public class Repository 
	{
		private List<Pipeline> pipelines;
		private List<Commit> commits;

		public Project Project { get; }

		public Repository(Project project)
		{
			Project = project;
			commits = new List<Commit>();
			pipelines = new List<Pipeline>();
		}

		public void CreatePipeline(Sprint sprintRelease)
        {
			pipelines.Add(PipelineFactory.CreatePipeline(this, sprintRelease));
        }

		public void Commit(Commit commit) 
		{
			commits.Add(commit);
		}

		public void RunPipeline(Sprint sprint) 
		{
			foreach (Pipeline pipeline in pipelines.Where(pipeline => pipeline.Sprint == sprint))
			{
				pipeline.Run();
			}
		}

		public bool IsPipelineRunning() 
		{
            foreach (Pipeline pipeline in pipelines)
            {
				if (pipeline.IsRunning)
                {
					return true;
                }
            }

			return false;
		}

		public List<Commit> GetCommits()
		{
			return commits;
		}
	}
}
