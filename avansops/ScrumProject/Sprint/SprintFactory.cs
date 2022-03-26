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
            Sprint sprint = new Sprint(999, start, end);
            repository.CreatePipeline(sprint);
            sprint.ProjectMembers.Add(creator);
            return sprint;
        }
    }
}
