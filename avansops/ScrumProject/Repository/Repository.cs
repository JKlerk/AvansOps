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

		public void CreatePipeline(SprintRelease sprintRelease)
        {
			pipelines.Add(PipelineFactory.CreatePipeline(this, sprintRelease));
        }

		public void Commit(Commit commit) 
		{
			commits.Add(commit);
		}

		public void RunPipeline(Sprint sprint) 
		{
			foreach (Pipeline pipeline in pipelines.Where(pipeline => pipeline.SprintRelease == sprint))
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

		public List<Pipeline> GetPipelines()
		{
			return pipelines;
		}

		public Pipeline GetPipeline(SprintRelease sprint)
        {
            foreach (Pipeline pipeline in pipelines)
            {
				if (pipeline.SprintRelease == sprint)
                {
					return pipeline;
                }
            }

			throw new Exception("No pipeline with given sprint exists");
        }
	}
}
