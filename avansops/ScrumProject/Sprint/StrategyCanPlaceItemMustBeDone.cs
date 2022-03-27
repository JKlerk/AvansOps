using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansOps
{
    class StrategyCanPlaceItemMustBeDone : IStrategyCanPlaceItem
    {
        public bool CanPlaceItem(SprintBackLogItem sprintBackLogItem)
        {
            return sprintBackLogItem.BackLogItem.IsDone();
        }
    }
}
