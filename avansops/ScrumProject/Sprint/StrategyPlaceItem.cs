using System;

namespace AvansOps {
	public abstract class StrategyPlaceItem
	{
		public abstract void OnPlace(SprintBackLogItem sprintBacklogItem, SprintPhase fromSprintPhase);

	}

}
