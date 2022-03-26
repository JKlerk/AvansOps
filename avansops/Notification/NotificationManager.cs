using System.Collections.Generic;
using System.Linq;
using AvansOps;

namespace AvansOps1.Notification {
	public static class NotificationManager {
		
		public static void Notify(List<Role> roles, Project project, string message) {
			foreach (var member in project.GetCurrentSprint().ProjectMembers)
			{
				if (member.Roles.Any(x => roles.Any(y => x == y)))
				{
					member.NotificationStrategy.Notify(member, message);
				}
			}
		}
		
		public static void Notify(ProjectMember projectMember, string message) {
			throw new System.NotImplementedException("Not implemented");
		}
	}

}
