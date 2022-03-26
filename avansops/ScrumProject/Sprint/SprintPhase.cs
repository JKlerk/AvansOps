using System;
using System.Collections.Generic;

namespace AvansOps {
	public class SprintPhase {
		public int Id { get; }
		public string Name { get; }
		public List<SprintBackLogItem> SprintBackLogItems { get; }

		public List<Role> RolesAuthorized { get; }

		public List<StrategyPlaceItem> StrategiesPlaceItem { get; }

		public SprintPhase(int id, string name, List<Role> rolesAuthorized)
		{
			Id = id;
			Name = name;
			this.RolesAuthorized = rolesAuthorized;
			StrategiesPlaceItem = new List<StrategyPlaceItem>();
			SprintBackLogItems = new List<SprintBackLogItem>();
		}
		public void PlaceItem(SprintBackLogItem sprintBackLogItem, SprintPhase fromSprintPhase) {
			SprintBackLogItems.Add(sprintBackLogItem);
			foreach (var strategyPlaceItem in StrategiesPlaceItem)
			{
				strategyPlaceItem.OnPlace(sprintBackLogItem, fromSprintPhase);
			}
		}
		public void RemoveItem(SprintBackLogItem item)
		{
			SprintBackLogItems.Remove(item);
		}

		public void AddStrategyPlaceItem(StrategyPlaceItem strategyPlaceItem)
		{
			StrategiesPlaceItem.Add(strategyPlaceItem);
		}
	}
}
