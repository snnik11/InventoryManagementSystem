using InventoryManagement.Domain.Contracts;
using InventoryManagement.Domain.General;

namespace InventoryManagement.Domain.ProductManagement
{
    //sealed class used to avoid the class to be inherited
    public sealed class BoxedProduct : Product, ISaveable
    {
        private int amountPerBox;
        

        public int AmountPerBox
        {
            get { return amountPerBox;}
            set { amountPerBox = value;}
        }

        public BoxedProduct(int id, string name, string? description,
        Price price, int maxAmountInStock, int amountPerBox) :
        base(id,name,description, price, UnitType.PerBox,maxAmountInStock)
        {
            AmountPerBox = amountPerBox;
        }

        public override void UseProduct(int items)
        {
            int smallestMultiple = 0;
            int batchSize ;

            while(true)
            {
                smallestMultiple++;
                if(smallestMultiple * AmountPerBox > items)
                {
                    batchSize = smallestMultiple * AmountPerBox;
                    break;
                }
            }
            base.UseProduct(batchSize);
        }

        public override void IncreaseStock()
        {
            AmountInStock +=AmountPerBox;
        }

        public override void IncreaseStock(int amount)
        {
            int newBoxStock = AmountInStock + amount * AmountPerBox;

            if (newBoxStock <= maxItemsInStock)
            {
                AmountInStock += amount * AmountPerBox;
            }
            else 
            {
                //overstock isnt stored
                AmountInStock = maxItemsInStock;

               Console.WriteLine($"{CreateSimpleProductRepresentation} stock overflow. {newBoxStock - AmountInStock} items ordered that couldn't be stored.");
            }

            if (AmountInStock > StockThreshold)
            {
                IsBelowStockTreshold = false;
            }
        }

        public string ConvertToStringForSaving()
        {
            return $"{Id}; {Name}; {Description}; {maxItemsInStock}; {Price.ItemPrice}; {(int)Price.Currency}; {(int)UnitType}; {1};    {AmountPerBox};";
        }

        public override object Clone()
        {
            return new BoxedProduct(0, this.Name, this.Description, new Price() {
                ItemPrice = this.Price.ItemPrice,
                Currency = this.Price.Currency
            }, this.maxItemsInStock, this.AmountPerBox);
        }

    }
}