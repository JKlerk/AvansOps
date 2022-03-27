using System;
using System.Collections.Generic;
using AvansOps.User;

namespace AvansOps.ScrumProject.Sprint {
	public class SprintPhase {
		public int Id { get; }
		public string Name { get; }
		public List<SprintBackLogItem> SprintBackLogItems { get; }
		public List<Role> RolesAuthorized { get; }
		public List<IStrategyPlaceItem> StrategiesPlaceItem { get; }
		public List<IStrategyCanPlaceItem> StrategiesCanPlaceItem { get; }

		public SprintPhase(int id, string name, List<Role> rolesAuthorized)
		{
			Id = id;
			Name = name;
			RolesAuthorized = rolesAuthorized;
			StrategiesPlaceItem = new List<IStrategyPlaceItem>();
			StrategiesCanPlaceItem = new List<IStrategyCanPlaceItem>();
			SprintBackLogItems = new List<SprintBackLogItem>();
		}

		public void PlaceItem(SprintBackLogItem sprintBackLogItem, SprintPhase fromSprintPhase) 
		{
			if (SprintBackLogItems.Contains(sprintBackLogItem))
            {
				throw new Exception("SprintBackLogItem is already placed in this phase");
            }

            foreach (var strategyCanPlaceItem in StrategiesCanPlaceItem)
            {
				if (!strategyCanPlaceItem.CanPlaceItem(sprintBackLogItem))
                {
					throw new Exception("Cannot place the item in the phase");
				}
			}

			SprintBackLogItems.Add(sprintBackLogItem);

			foreach (var strategyPlaceItem in StrategiesPlaceItem)
			{
				strategyPlaceItem.OnPlace(sprintBackLogItem, fromSprintPhase);
			}
		}

		public void RemoveItem(SprintBackLogItem item)
		{
			if (!SprintBackLogItems.Contains(item))
			{
				throw new Exception("SprintBackLogItem is not place in this phase");
			}

			SprintBackLogItems.Remove(item);
		}

		public void AddStrategyPlaceItem(IStrategyPlaceItem strategyPlaceItem)
		{
			StrategiesPlaceItem.Add(strategyPlaceItem);
		}

		public void AddStrategyCanPlaceItem(IStrategyCanPlaceItem strategyCanPlaceItem)
		{
			StrategiesCanPlaceItem.Add(strategyCanPlaceItem);
		}
	}
}
