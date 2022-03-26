using System;
using System.Collections.Generic;
using System.Linq;

namespace AvansOps {
	public class BackLogItem {
		private int id;
		private string name;
		private string description;
		private bool isDone;
		
		private ProjectMember projectMember;
		private List<BackLogItemActivity> backLogItemActivities;
		private List<Thread> threads;
		private SprintBackLogItem sprintBackLogItem;

		public BackLogItem(int id, string name, string description)
		{
			this.id = id;
			this.name = name;
			this.description = description;
			projectMember = null;
			backLogItemActivities = new List<BackLogItemActivity>();
			threads = new List<Thread>();
		}

		public void CreateThread(ProjectMember projectMember, string name, string description) {
			threads.Add(new Thread(threads.Count + 1, name, description, projectMember));
		}
		public string GetName() {
			return name;
		}
		public string GetDescription() {
			return description;
		}
		public void CreateActivity(string name, string description, ProjectMember member) {
			backLogItemActivities.Add(new BackLogItemActivity(1, name, description, member, this));
		}
		public bool IsActivitiesDone()
		{
			var doneList = backLogItemActivities.Where(activity => activity.GetBackLogItem().IsDone()).ToList();
			return doneList.Count == backLogItemActivities.Count;
		}
		public void SetName(string name)
		{
			this.name = name;
		}
		public void SetDescription(string description)
		{
			this.description = description;
		}
		private bool IsBoundToSprint()
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
		
	}

}
