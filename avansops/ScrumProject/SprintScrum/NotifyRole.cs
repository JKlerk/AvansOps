using System.Collections.Generic;
using AvansOps.Notification;
using AvansOps.User;

namespace AvansOps.ScrumProject.SprintScrum {
	public class NotifyRole : IStrategyPlaceItem
	{
		public List<Role> Roles { get; }
		public Project Project { get; }
		public string Message { get; }

		public NotifyRole(List<Role> roles, Project project, string message)
		{
			Roles = roles;
			Project = project;
			Message = message;
		}

		public void OnPlace(SprintBackLogItem sprintBacklogItem, SprintPhase fromSprintPhase)
		{
			if(fromSprintPhase != null)NotificationManager.Notify(Roles, Project, Message);
		}
	}

}
