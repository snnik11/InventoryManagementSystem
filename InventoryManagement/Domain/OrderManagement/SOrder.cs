using System.Text;

namespace InventoryManagement.Domain.OrderManagement
{
    public class Order
    {
        public DateTime OrderFulfilmentDate {get; set;}
        public int OrderId { get; private set;}
        public List<OrderItem> OrderItems {get; } //OrderItem is the type

        public bool Fulfilled {get; set;} = false; //important to note

        public Order()
        {
            OrderId = new Random().Next(99999); //generate random Id number
            //next() returns integer number
            int numberofSeconds = new Random().Next(100);
            OrderFulfilmentDate = DateTime.Now.AddSeconds(numberofSeconds);

            OrderItems = new List<OrderItem>();

        }

        public string ShowOrderDetails()
        {
            //class type stringbuilder modifies string without creating new object
            StringBuilder orderDetails = new StringBuilder(); 

            orderDetails.AppendLine($"Order ID: {OrderId}");
            orderDetails.AppendLine($"Order fulfilment date: {OrderFulfilmentDate}");

            if (OrderItems != null)
            {
                foreach (OrderItem item in OrderItems)
                {
                    orderDetails.AppendLine();
                    //will return  ProductId, ProductName and AmountOrdered
                }
            }
            return orderDetails.ToString();
            //should return OrderId, OrderFulfilmentDate,ProductId, ProductName and AmountOrdered

        }


    }
}