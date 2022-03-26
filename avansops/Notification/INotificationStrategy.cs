using AvansOps;

namespace AvansOps1.Notification {
	public abstract class INotificationStrategy
	{
		public abstract void Notify(ProjectMember projectMember, string message);
		
	}

}
