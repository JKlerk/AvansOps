using System;

namespace AvansOps.ScrumProject.Sprint {
	public static class SprintFactory 
	{
		public static Sprint CreateReviewSprint(DateTime start, DateTime end, ProjectMember creator)
		{
            Sprint sprint = new SprintReview(999, start, end);
            sprint.AddProjectMember(creator);
            return sprint;
        }

        public static Sprint CreateReleaseSprint(Repository.Repository repository, DateTime start, DateTime end, ProjectMember creator)
        {
            SprintRelease sprint = new SprintRelease(999, start, end);
            repository.CreatePipeline(sprint);
            sprint.AddProjectMember(creator);
            return sprint;
        }
    }
}
