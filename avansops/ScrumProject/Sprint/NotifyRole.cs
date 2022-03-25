using System;
using System.Collections.Generic;

namespace AvansOps {
	public class NotifyRole : StrategyPlaceItem
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

		public override void OnPlace(SprintBackLogItem sprintBacklogItem, SprintPhase? fromSprintPhase)
		{
			if(fromSprintPhase != null)NotificationManager.Notify(Roles, Project, Message);
		}
	}

}
