using System.Collections.Generic;
using AvansOps.Notification;
using AvansOps.User;

namespace AvansOps.ScrumProject {
	public class ProjectMember {
		public INotificationStrategy NotificationStrategy { get; }
		public User.User User { get; }
		
		public List<Role> Roles { get; set; }

		public ProjectMember(User.User user, List<Role> roles, INotificationStrategy notificationStrategy)
		{
			User = user;
			Roles = roles;
			NotificationStrategy = notificationStrategy;
		}
	}

}
