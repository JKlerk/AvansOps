namespace AvansOps.ScrumProject.Sprint
{
    class StrategyCanPlaceItemMustBeDone : IStrategyCanPlaceItem
    {
        public bool CanPlaceItem(SprintBackLogItem sprintBackLogItem)
        {
            return sprintBackLogItem.BackLogItem.IsDone();
        }
    }
}
