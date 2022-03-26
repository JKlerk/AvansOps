using System.Collections.Generic;
using System.Linq;
using AvansOps;

namespace AvansOps 
{
	public static class NotificationManager {
		
		public static void Notify(List<Role> roles, Project project, string message) 
		{
			foreach (var member in project.GetCurrentSprint().ProjectMembers)
			{
				if (member.Roles.Any(x => roles.Any(y => x == y)))
				{
					Notify(member, message);
				}
			}
		}
		
		public static void Notify(ProjectMember projectMember, string message) 
		{
			projectMember.NotificationStrategy.Notify(projectMember, message);
		}
	}
}
