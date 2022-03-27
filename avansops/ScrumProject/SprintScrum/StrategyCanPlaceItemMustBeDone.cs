namespace AvansOps.ScrumProject.SprintScrum
{
    class StrategyCanPlaceItemMustBeDone : IStrategyCanPlaceItem
    {
        public bool CanPlaceItem(SprintBackLogItem sprintBackLogItem)
        {
            return sprintBackLogItem.BackLogItem.IsDone();
        }
    }
}
