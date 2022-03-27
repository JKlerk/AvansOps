using System;
using System.Collections.Generic;

namespace AvansOps 
{
	public abstract class Sprint
	{
		public int Id { get; }
		public SprintState SprintState { get; protected set; }
		public List<SprintBackLogItem> SprintBackLogItems { get; } 
		public List<ProjectMember> ProjectMembers { get; }

		public DateTime DateStart { get; }
		public DateTime DateEnd { get; }

		public Sprint(int id, DateTime dateStart, DateTime dateEnd)
		{
			Id = id;
			DateStart = dateStart;
			DateEnd = dateEnd;
			SprintBackLogItems = new List<SprintBackLogItem>();
			SprintState = SprintState.OnGoing;
			ProjectMembers = new List<ProjectMember>();
		}

		public void Cancel()
		{
			if (SprintState == SprintState.OnGoing)
			{
				SprintState = SprintState.Canceled;
			}
			else
			{
				throw new Exception("Sprint is already closed!");
			}
		}

		public void Finish()
        {
			if (SprintState == SprintState.OnGoing)
            {
				SprintState = SprintState.Finished;
            }
			else
            {
				throw new Exception("Sprint is already closed!");
			}
		}

		public SprintBackLogItem AddSprintBacklogItem(BackLogItem backLogItem)
		{
			var item = CreateSprintBackLogItem(backLogItem);
			if (SprintBackLogItems.Exists(x => x.Id == backLogItem.Id)) throw new Exception("SprintBacklog item already exists");
			SprintBackLogItems.Add(item);
			return item;
		}

		private SprintBackLogItem CreateSprintBackLogItem(BackLogItem backLogItem)
		{
			return new SprintBackLogItem(1, this, backLogItem);
		}

		public void AddProjectMember(ProjectMember member)
		{
			if (ProjectMembers.Contains(member))
            {
				throw new Exception("Project already contains projectmember");
			}

			ProjectMembers.Add(member);
		}
		
		public void RemoveProjectMember(ProjectMember member)
		{
			if (!ProjectMembers.Contains(member))
			{
				throw new Exception("Project does not contain projectmember");
			}

			if (ProjectMembers.Count == 1)
            {
				throw new Exception("Can't remove last member of the sprint");
			}

			ProjectMembers.Remove(member);
		}
	}
}
