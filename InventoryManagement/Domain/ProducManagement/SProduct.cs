using InventoryManagement.Domain.Contracts;
using InventoryManagement.Domain.General;

namespace InventoryManagement.Domain.ProductManagement
{
    //ICloneable creates instance of a class
    //which will create same value as existing value
    public abstract partial class Product : ICloneable
    {
        //fields
        private int id; //encapsulation -data is private
        private string name = string.Empty;
        private string? description; //? for marking it as nullable in case wanna leave it empty

        protected int maxItemInStock = 0; //doesnt need to be exposed using properties

        //private UnitType unitType; //defined in properties
        //private int amountInStock = 0; //will keep track of amount of items in stock for the product
        //private bool isBelowStockThreshold = false;

          //properties
        public int Id 
        {
            get { return id;}
            set {id = value;}
        }

        public string Name
        {
            get { return name;}
            set {name = value;}
        }

        public string? Description
        {
            get { return description;}
            set 
            {
                if (value == null)
                {
                    description = string.Empty;
                }
                else 
                {
                     //if the length of name is longer than 50, the value after 50 will be truncated
                //this could be a very specific business requirement wherein a Db can only accept 50 characters
                //[..50] is a range operator - it will all characters until we reach 50
                //range operator works on a collection- this string here is seen as collection of characters
                
                    description = value.Length > 250 ? value[..250] : value;
                }
            }
           
        }
        public Price price { get; set;}

        public UnitType UnitType { get; set;}

        //protected to be accessible to parent-child classes
        public int AmountInStock { get; protected set;} //only exposing for get for regular get read
        public bool IsBelowStockTreshold { get; protected set;}


        //only called if id needed
        public Product(int id) : this(id, string.Empty)
        {

        }

        //called if id and name only needed
        public Product(int id, string name)
        {
            Id = id;
            Name = name;
        }

        //called for all parameters
        public Product(int id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            UnitType = unitType;
            maxItemsInStock = maxAmountInStock;

            if ( AmountInStock < StockTreshold) 
            {
                IsBelowStockTreshold = true;
            }
        }


        //called to Update BelowStockThreshold to true
        public void UpdateLowStock()
        {
            if (AmountInStock < StockTreshold)
            {
                IsBelowStockTreshold = true;
            }
        }

        //called to Use products for no. of items
        //virtual method can be overidden in derived class
        public virtual void UseProduct(int items)
        {
            if (items <= AmountInStock)
            {
                //use the items
                AmountInStock -= items;

                UpdateLowStock();
                Log ($"Amount in stock updated. Now there are {AmountInStock} items left in the stock");
            }
        }

        //called from BoxedProduct class
        public abstract void IncreaseStock();

        //called to increase the stock for new stock or show the max Stock
        public virtual void IncreaseStock(int amount)
        {
            int newStock = AmountInStock + amount;

            if( newStock <= maxItemsInStock)
            {
                AmountInStock += amount;
            }
            else 
            {
                //we store only the max number of items not overstocked ones
                AmountInStock = maxAmountInStock;
                Log($"{CreateSimpleProductRepresentation} stock overflow. {newStock - AmountInStock} items couldn't be stored");
            }
            if (AmountInStock > StockTreshold)
            {
                IsBelowStockTreshold = false;
            }
        }

        //called to decrease stock
        protected virtual void DecreaseStock(int items, string reason)
        {
            if (items <= AmountInStock)
            {
                //decrease stock with specific number
                AmountInStock -= items;
            }
            else 
            {
                AmountInStock = 0;
            }
            Log(reason);
        }

        public virtual string DisplayDetailsShort()
        {
            return $"{Id}. {Name} \n{AmountInStock} items in stock";
        }

        public virtual string DisplayDetailsFull()
        {
            StringBuilder sb= new StringBuilder; //dynamically expands memory in heap to fit in modified string

            sb.Append($"{Id} {Name} \n{Description} \n{Price} \n{AmountInStock} items in stock");

            if (IsBelowStockTreshold)
            {
                sb.Append("Stock is Low!");
            }
            return sb.ToString();
        }

        //called to the total price for amount in the stock
        public virtual double GetProductsStockValue()
        {
            return Price.ItemPrice * AmountInStock;
        }

        //to be used by other classes
        public abstract object Clone();

    }
}   