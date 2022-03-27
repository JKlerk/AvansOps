using System;

namespace AvansOps {
	public class SprintBackLogItem {
		public int Id { get; }

		public Sprint Sprint { get; }
		public BackLogItem BackLogItem { get; }

		public SprintBackLogItem(int id, Sprint sprint, BackLogItem backLogItem)
		{
			this.Id = id;
			Sprint = sprint;
			BackLogItem = backLogItem;
		}
		
		public void SetToDone() {
			BackLogItem.SetToDone();
		}

	}

}
