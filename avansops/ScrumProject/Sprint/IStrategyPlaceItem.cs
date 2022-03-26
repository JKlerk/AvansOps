using System;

namespace AvansOps 
{
	public interface IStrategyPlaceItem
	{
		public void OnPlace(SprintBackLogItem sprintBacklogItem, SprintPhase fromSprintPhase);
	}
}
