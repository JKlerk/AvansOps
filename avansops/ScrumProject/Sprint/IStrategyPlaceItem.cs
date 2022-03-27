namespace AvansOps.ScrumProject.Sprint 
{
	public interface IStrategyPlaceItem
	{
		public void OnPlace(SprintBackLogItem sprintBacklogItem, SprintPhase fromSprintPhase);
	}
}
