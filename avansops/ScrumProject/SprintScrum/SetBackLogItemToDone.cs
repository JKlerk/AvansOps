namespace AvansOps.ScrumProject.SprintScrum {
	public class SetBackLogItemToDone : IStrategyPlaceItem  {
		private void SetToDone(SprintBackLogItem sprintBackLogItem) {
			sprintBackLogItem.BackLogItem.SetToDone();
		}

		public void OnPlace(SprintBackLogItem sprintBacklogItem, SprintPhase fromSprintPhase)
		{
			SetToDone(sprintBacklogItem);
		}
	}

}
