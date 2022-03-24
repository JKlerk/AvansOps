using System;

namespace AvansOps {
	public abstract class INotificationStrategy {
		public void Notifiy(ref ProjectMember projectMember, ref string message) {
			throw new System.NotImplementedException("Not implemented");
		}

		private ProjectMember projectMember;

	}

}
