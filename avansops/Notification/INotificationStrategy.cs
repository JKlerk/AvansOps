using AvansOps;

namespace AvansOps.Notification {
	public abstract class INotificationStrategy
	{
		public abstract void Notify(ProjectMember projectMember, string message);
		
	}

}
