using System;

namespace AvansOps {
	public static class SprintFactory 
	{
		public static Sprint CreateReviewSprint(DateTime start, DateTime end, ProjectMember creator)
		{
            Sprint sprint = new SprintReview(999, start, end);
            sprint.ProjectMembers.Add(creator);
            return sprint;
        }

        public static Sprint CreateReleaseSprint(Repository repository, DateTime start, DateTime end, ProjectMember creator)
        {
            Pipeline pipeline = PipelineFactory.CreatePipeline(repository);
            Sprint sprint = new SprintRelease(999, start, end, pipeline);
            sprint.ProjectMembers.Add(creator);
            return sprint;
        }
    }
}
