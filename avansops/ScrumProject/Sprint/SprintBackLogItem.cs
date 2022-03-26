using System;

namespace AvansOps {
	public class SprintBackLogItem {
		private int id;
		
		public Sprint Sprint { get; }
		public BackLogItem BackLogItem { get; }

		public SprintBackLogItem(int id, Sprint sprint, BackLogItem backLogItem)
		{
			this.id = id;
			Sprint = sprint;
			BackLogItem = backLogItem;
		}
		
		public void SetToDone() {
			BackLogItem.SetToDone();
		}

	}

}
