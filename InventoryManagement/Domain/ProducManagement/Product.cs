using BethanyPieShop.InventoryManagement.Domain.General;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanyPieShop.InventoryManagement.Domain.ProducManagement
{
    public partial class Product
    {
        //fields
        private int id; //encapsulation -data is private
        private string name = string.Empty;
        private string? description; //? for marking it as nullable in case wanna leave it empty

        private int maxItemInStock = 0; //doesnt need to be exposed using properties

        //private UnitType unitType; //defined in properties
        //private int amountInStock = 0; //will keep track of amount of items in stock for the product
        //private bool isBelowStockThreshold = false;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        //properties
        public string Name
        {
            get { return name; }
            set
            {
                //if the length of name is longer than 50, the value after 50 will be truncated
                //this could be a very specific business requirement wherein a Db can only accept 50 characters
                //[..50] is a range operator - it will all characters until we reach 50
                //range operator works on a collection- this string here is seen as collection of characters
                name = value.Length > 50 ? value[..50] : value;
            }
        }

        public string? Description
        {
            get { return description; }
            set
            {
                if (value == null)
                {
                    description = string.Empty;
                }
                else
                {

                    description = value.Length > 250 ? value[..250] : value;
                }

            }
        }

        public UnitType UnitType { get; set; }

        public int AmountInStock { get; private set; } //only exposing for get for regular get read

        public bool IsBelowStockThreshold { get; private set; }

        public Price Price { get; set; }
        //functions
        public void UseProduct(int items)
        {
            if (items <= AmountInStock)
            {
                //use the items
                AmountInStock -= items;
                UpdateLowStock();
                Log($"Stock has been updated. Now there are {AmountInStock} items");
            }
            else
            {
                Log($"There are no enough stock for {CreateSimpleProductRepresentation()}. {AmountInStock} available but {items} requested");
            }
        }
       
    }
}
