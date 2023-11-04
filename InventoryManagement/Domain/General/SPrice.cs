namespace InventoryManagement.Domain.General
{
    public class Price
    {
        public double ItemPrice {get; set;}
        public Currency Currency_variable { get; set;}

        public override string ToString() 
        {
            return $"{ItemPrice} {Currency_variable}";
        }

           //public Price(double price, Currency currency)
        //{
        //    ItemPrice = price;
        //    Currency = currency;
        //} .//now called from program class by object intializer
    }
}