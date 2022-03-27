using System;
using System.Collections.Generic;
using System.Linq;
using AvansOps.ScrumProject.SprintScrum;

namespace AvansOps.ScrumProject {
	public class BackLogItem {
		public int Id { get; }
		private string name;
		private string description;
		private bool isDone;
		
		private ProjectMember projectMember;
		private List<BackLogItemActivity> backLogItemActivities;
		private List<Thread> threads;
		private SprintBackLogItem sprintBackLogItem;

		public BackLogItem(int id, string name, string description)
		{
			Id = id;
			this.name = name;
			this.description = description;
			isDone = false;
			projectMember = null;
			backLogItemActivities = new List<BackLogItemActivity>();
			threads = new List<Thread>();
		}

		public void AddThread(Thread thread)
		{
			if (isDone) throw new Exception("Item is marked as done, you cannot make a thread");
			threads.Add(thread);
		}
		public string GetName() {
			return name;
		}
		public string GetDescription() {
			return description;
		}
		public void CreateActivity(string name, string description, ProjectMember member) {
			backLogItemActivities.Add(new BackLogItemActivity(1, name, description, member));
		}
		public bool IsActivitiesDone()
		{
			var doneList = backLogItemActivities.Where(activity => activity.IsAcitvityDone()).ToList();
			return doneList.Count == backLogItemActivities.Count;
		}
		public void SetName(string name)
		{
			if (sprintBackLogItem != null) throw new Exception("Cannot edit item that is in a sprint");
			this.name = name;
		}
		public void SetDescription(string description)
		{
			if (sprintBackLogItem != null) throw new Exception("Cannot edit item that is in a sprint");
			this.description = description;
		}
		
		public bool IsBoundToSprint()
		{
			return sprintBackLogItem != null;
		}
		
		public bool IsDone()
		{
			return isDone;
		}
		public void SetSprintBackLogItem(SprintBackLogItem sprintBackLogItem)
		{
			this.sprintBackLogItem = sprintBackLogItem;
		}
		public void SetToDone()
		{
			foreach (var thread in GetThreads())
			{
				thread.BackLogItemIsDone = true;
			}
			isDone = true;
		}

		public void SetProjectMember(ProjectMember member)
		{
			projectMember = member;
		}

		public ProjectMember GetProjectMember()
		{
			return projectMember;
		}

		public List<Thread> GetThreads()
		{
			return threads;
		}

		public List<BackLogItemActivity> GetBackLogItemActivities()
		{
			return backLogItemActivities;
		}
		
	}

}
