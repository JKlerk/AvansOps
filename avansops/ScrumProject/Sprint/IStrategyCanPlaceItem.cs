using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansOps
{
    public interface IStrategyCanPlaceItem
    {
        public bool CanPlaceItem(SprintBackLogItem sprintBackLogItem);
    }
}
