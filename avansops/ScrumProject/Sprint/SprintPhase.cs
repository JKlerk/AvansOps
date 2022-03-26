using System;
using System.Collections.Generic;

namespace AvansOps {
	public class SprintPhase {
		public int Id { get; }
		public string Name { get; }
		private List<SprintBackLogItem> sprintBackLogItems;
		private List<Role> rolesAuthorized;

		private List<StrategyPlaceItem> strategiesPlaceItem;

		public SprintPhase(int id, string name, List<Role> rolesAuthorized)
		{
			Id = id;
			Name = name;
			this.rolesAuthorized = rolesAuthorized;
			strategiesPlaceItem = new List<StrategyPlaceItem>();
			sprintBackLogItems = new List<SprintBackLogItem>();
		}
		public void PlaceItem(SprintBackLogItem sprintBackLogItem, SprintPhase fromSprintPhase) {
			sprintBackLogItems.Add(sprintBackLogItem);
			foreach (var strategyPlaceItem in strategiesPlaceItem)
			{
				strategyPlaceItem.OnPlace(sprintBackLogItem, fromSprintPhase);
			}
		}
		public void RemoveItem(SprintBackLogItem item)
		{
			sprintBackLogItems.Remove(item);
		}

		public List<SprintBackLogItem> GetSprintBackLogItems()
		{
			return sprintBackLogItems;
		}

		public void AddStrategyPlaceItem(StrategyPlaceItem strategyPlaceItem)
		{
			strategiesPlaceItem.Add(strategyPlaceItem);
		}

		public List<Role> GetRolesAuthorized() {
			return rolesAuthorized;
		}

		public List<StrategyPlaceItem> GetStrategiesPlaceItem()
		{
			return strategiesPlaceItem;
		}
		
	}
}
