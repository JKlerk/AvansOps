using System;
using System.Collections.Generic;
using AvansOps.Notification;

namespace AvansOps {
	public class ProjectMember {
		public INotificationStrategy NotificationStrategy { get; }
		public User User { get; }
		
		public List<Role> Roles { get; set; }

		public ProjectMember(User user, List<Role> roles, INotificationStrategy notificationStrategy)
		{
			User = user;
			Roles = roles;
			NotificationStrategy = notificationStrategy;
		}
	}

}
