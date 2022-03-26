using System;
using System.Collections.Generic;

namespace AvansOps 
{
	public class Sprint
	{
		private int id;
		public SprintState SprintState { get; protected set; }
		public List<SprintBackLogItem> SprintBackLogItems { get; } 
		public List<ProjectMember> ProjectMembers { get; }

		private DateTime dateStart;
		private DateTime dateEnd;

		public Sprint(int id, DateTime dateStart, DateTime dateEnd)
		{
			this.id = id;
			this.dateStart = dateStart;
			this.dateEnd = dateEnd;
			SprintBackLogItems = new List<SprintBackLogItem>();
			SprintState = SprintState.OnGoing;
			ProjectMembers = new List<ProjectMember>();
		}

		public void Cancel()
		{
			SprintState = SprintState.Canceled;
		}

		public virtual void Finish()
        {
			if (SprintState != SprintState.Finished || SprintState != SprintState.Canceled)
            {
				SprintState = SprintState.Finished;
            }
			else
            {
				Console.WriteLine("Sprint is already closed!");
            }
        }

		public SprintBackLogItem AddSprintBacklogItem(BackLogItem backLogItem)
		{
			var item = CreateSprintBackLogItem(backLogItem);
			SprintBackLogItems.Add(item);
			return item;
		}

		private SprintBackLogItem CreateSprintBackLogItem(BackLogItem backLogItem)
		{
			return new SprintBackLogItem(1, this, backLogItem);
		}

		public void AddProjectMember(ProjectMember member)
		{
			ProjectMembers.Add(member);
		}
		
		public void RemoveProjectMember(ProjectMember member)
		{
			ProjectMembers.Remove(member);
		}
	}
}
