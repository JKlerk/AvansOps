namespace AvansOps.ScrumProject.SprintScrum 
{
	public interface IStrategyPlaceItem
	{
		public void OnPlace(SprintBackLogItem sprintBacklogItem, SprintPhase fromSprintPhase);
	}
}
