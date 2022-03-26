using System;
using System.Collections.Generic;

namespace AvansOps 
{
	public abstract class Sprint
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

		public void Finish()
        {
			if (SprintState != SprintState.Finished || SprintState != SprintState.Canceled)
            {
				TryFinish();
            }
			else
            {
				Console.WriteLine("Sprint is already closed!");
            }
        }

		protected abstract void TryFinish();

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
