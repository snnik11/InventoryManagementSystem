namespace InventoryManagement.Domain.OrderManagement
{
    public class OrderItem
    {
        public int OrderId { get; set;}
        public int ProductId { get; set;}
        public string ProductName {get; set; } = string.Empty;
        public int AmountOrdered {get; set;}

        public override string ToString()
        {
            return $"Product ID: {ProductId}- Product Name : {ProductName}- Amount ordered : {AmountOrdered}";
        } 
    }
}