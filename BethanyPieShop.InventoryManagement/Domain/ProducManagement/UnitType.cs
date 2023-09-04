using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanyPieShop.InventoryManagement.Domain.ProducManagement
{
    public enum UnitType //special class to save group of constants
    {
        //enum items below will be unchanged/ read-only
        PerItem,
        PerBox,
        PerKg
    }
}
