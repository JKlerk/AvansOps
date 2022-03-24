using System;

namespace AvansOps {
	public abstract class StrategyPlaceItem {
		public void OnPlace(ref SprintBackLogItem backlogItem) {
			throw new System.NotImplementedException("Not implemented");
		}

		private SprintPhase[] sprintPhases;

	}

}
