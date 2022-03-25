using System;

namespace AvansOps {
	public abstract class INotificationStrategy
	{
		public abstract void Notify(ProjectMember projectMember, string message);

		private ProjectMember projectMember;

	}

}
