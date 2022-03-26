using System;

namespace AvansOps {
	public class SprintFactory {
		public static Sprint CreateSprint(SprintType sprintType, DateTime start, DateTime end, ProjectMember creator)
		{
			Sprint sprint = new Sprint(1, sprintType, start, end);
			sprint.ProjectMembers.Add(creator);
			return sprint;
		}

	}

}
