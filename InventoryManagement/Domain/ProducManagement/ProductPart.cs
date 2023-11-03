using BethanyPieShop.InventoryManagement.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanyPieShop.InventoryManagement.Domain.ProducManagement
{
   public partial class Product
    {
        public static int StockThreshhold = 5; //initial value

        public static void ChangeStockThreshhold(int newStockThreshhold)
        {
            if (newStockThreshhold > 0)
            {
                StockThreshhold = newStockThreshhold;
            }
        }
        public void UpdateLowStock()
        {
            if (AmountInStock < StockThreshhold)
            {
                IsBelowStockThreshold = true;
            }
        }
        private void Log(string message)
        {
            Console.WriteLine(message);
        }
        private string CreateSimpleProductRepresentation()
        {
            return $"Product {id} ({name})";
        }
        public void IncreaseStock()
        {
            AmountInStock++;
        }

        public void IncreaseStock(int amount)
        {
            int newStock = AmountInStock + amount;
            if (newStock <= maxItemInStock)
            {
                AmountInStock += amount;
            }
            else
            {
                AmountInStock = maxItemInStock;
                //not storing the excessive stock
                Log($"{CreateSimpleProductRepresentation} has been stocked extra. {newStock - AmountInStock} items couldnt be stored");
            }

            if (AmountInStock > StockThreshhold)
            {
                IsBelowStockThreshold = false;
                //to check UpdateLowStock();
            }
        }
        public void DescreaseStock(int items, string reason)
        {
            if (items <= AmountInStock)
            {
                AmountInStock -= items;
            }
            else
            {
                AmountInStock = 0;
            }
            UpdateLowStock();
            Log(reason);
        }
        public string DisplayDetailsShort()
        {
            return $"{id} {name} {AmountInStock} items in the stock ";

        }

        public string DisplayDetailsFull()
        {
            //StringBuilder sb = new(); //dynamically expands memory in heap to fit in modified string
            ////ToDO - Add price 
            //sb.Append($"{id} {name} \n{description}\n{AmountInStock} items in the stock");

            //if (IsBelowStockThreshold) //default is true?
            //{
            //    sb.Append("\n STOCK IS LOW");
            //}
            //return sb.ToString(); //?
            return DisplayDetailsFull(""); //?
        }
        public string DisplayDetailsFull(string extraDetails)
        {
            StringBuilder sb = new();
            sb.Append($"{id} {name} \n{Description} \n{AmountInStock} items in the stock");
            sb.Append(extraDetails);

            if (IsBelowStockThreshold)
            {
                sb.Append("\n STOCK IS LOW");
            }
            return sb.ToString();

        }

        //constructors
        public Product(int Id, string name)
        {
            this.Id = id;
            Name = name;
        }

        public Product(int id) : this(id, string.Empty)
        //'this' was added here to avoid code duplication from previous constructor
        {
            //Id = id;
        }

        public Product(int id, string name, string? description,
            Price price,
            UnitType unitType, int maxAmountInStock)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            UnitType = unitType;

            maxItemInStock = maxAmountInStock;

            UpdateLowStock();
        }
    }
}
