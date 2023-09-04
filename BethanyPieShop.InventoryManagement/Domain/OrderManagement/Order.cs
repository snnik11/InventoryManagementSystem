using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanyPieShop.InventoryManagement.Domain.OrderManagement
{
    public class Order
    {
        public bool FulFilled { get; set; } = false;
        public int Id { get; private set; }
        public  DateTime OrderFulfilmentDate { get; private set; }
        public List<OrderItem> OrderItems { get; }

        public Order()
        {
            Id = new Random().Next(9999999);
            int numberOfSeconds = new Random().Next(100);
            OrderFulfilmentDate = DateTime.Now.AddSeconds(numberOfSeconds);
            OrderItems = new List<OrderItem>();
        }
       
    }
}
