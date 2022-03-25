using System;
using System.Collections.Generic;

namespace AvansOps {
	public class Sprint
	{
		private int id;
		private SprintType sprintType;
		public SprintState SprintState { get; }
		private List<SprintBackLogItem> sprintBackLogItems;

		public List<ProjectMember> ProjectMembers { get; }

		private DateTime dateStart;
		private DateTime dateEnd;

		public Sprint(int id, SprintType sprintType, DateTime dateStart, DateTime dateEnd)
		{
			this.id = id;
			this.sprintType = sprintType;
			this.dateStart = dateStart;
			this.dateEnd = dateEnd;
			sprintBackLogItems = new List<SprintBackLogItem>();
			SprintState = SprintState.OnGoing;
			ProjectMembers = new List<ProjectMember>();
		}

		public void Cancel()
		{
			throw new System.NotImplementedException("Not implemented");
		}

		public SprintBackLogItem AddSprintBacklogItem(BackLogItem backLogItem)
		{
			var item = CreateSprintBackLogItem(backLogItem);
			sprintBackLogItems.Add(item);
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
