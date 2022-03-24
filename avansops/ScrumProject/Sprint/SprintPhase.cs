using System;

namespace AvansOps {
	public class SprintPhase {
		private int id;
		private string name;
		private SprintBackLogItem[] sprintBackLogItems;
		private Role[] rolesAuthorized;

		public SprintPhase(ref string name, ref Role[] rolesAuthorised, ref StrategyPlaceItem[] strategiesPlaceItem) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void PlaceItem(ref SprintBackLogItem sprintBackLogItem) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void RemoveItem() {
			throw new System.NotImplementedException("Not implemented");
		}
		public Role[] GetRolesAuthorized() {
			return this.rolesAuthorized;
		}

		private StrategyPlaceItem strategyPlaceItem;

		private Project[] projects;

	}

}
