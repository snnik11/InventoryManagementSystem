namespace InventoryManagement.Domain.ProductManagement
{
    public partial class Product
    {
        public static int StockTreshold = 5;

        public static void ChangeStockThreshold(int newStockThreshold)
        {
            if (newStockThreshold > 0)
            {
                StockThreshold = newStockThreshold;
            }
        }

        protected void log (string message)
        {
            //could be written to a file
            Console.WriteLine(message);
        }

        protected string CreateSimpleProductRepresentation()
        {
            return $"Product {Id} ({Name})";
        }
    }
}