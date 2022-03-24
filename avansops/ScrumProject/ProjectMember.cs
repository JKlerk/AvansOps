using System;

namespace AvansOps {
	public class ProjectMember {
		public void SetRole(ref Role role) {
			throw new System.NotImplementedException("Not implemented");
		}

		private User user;
		private INotificationStrategy iNotificationStrategy;
		private Sprint sprint;
		private Role role;

		private Commit commit;
		private ThreadMessage threadMessage;
		private BackLogItem backLogItem;
		private BackLogItemActivity backLogItemActivity;
		private Project[] projects;

	}

}
