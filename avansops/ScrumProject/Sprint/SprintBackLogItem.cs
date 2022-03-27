namespace AvansOps.ScrumProject.Sprint {
	public class SprintBackLogItem {
		public int Id { get; }

		public Sprint Sprint { get; }
		public BackLogItem BackLogItem { get; }

		public SprintBackLogItem(int id, Sprint sprint, BackLogItem backLogItem)
		{
			Id = id;
			Sprint = sprint;
			BackLogItem = backLogItem;
		}
		
		public void SetToDone() {
			BackLogItem.SetToDone();
		}

	}

}
