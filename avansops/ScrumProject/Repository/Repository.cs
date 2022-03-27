using System;
using System.Collections.Generic;
using System.Linq;
using AvansOps.ScrumProject.Repository.Pipeline;
using AvansOps.ScrumProject.Sprint;

namespace AvansOps.ScrumProject.Repository 
{
	public class Repository 
	{
		private List<Pipeline.Pipeline> pipelines;
		private List<Commit> commits;

		public Project Project { get; }

		public Repository(Project project)
		{
			Project = project;
			commits = new List<Commit>();
			pipelines = new List<Pipeline.Pipeline>();
		}

		public void CreatePipeline(SprintRelease sprintRelease)
        {
			pipelines.Add(PipelineFactory.CreatePipeline(this, sprintRelease));
        }

		public void Commit(Commit commit) 
		{
			commits.Add(commit);
		}

		public void RunPipeline(Sprint.Sprint sprint) 
		{
			foreach (Pipeline.Pipeline pipeline in pipelines.Where(pipeline => pipeline.SprintRelease == sprint))
			{
				pipeline.Run();
			}
		}

		public bool IsPipelineRunning() 
		{
            foreach (Pipeline.Pipeline pipeline in pipelines)
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

		public List<Pipeline.Pipeline> GetPipelines()
		{
			return pipelines;
		}

		public Pipeline.Pipeline GetPipeline(SprintRelease sprint)
        {
            foreach (Pipeline.Pipeline pipeline in pipelines)
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
