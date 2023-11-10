using InventoryManagement.Domain.Contracts;
using InventoryManagement.Domain.General;
using InventoryManagement.Domain.OrderManagement;
using InventoryManagement.Domain.ProductManagement;

namespace InventoryManagement
{
    internal class Utilities
    {
        private static List<Product> inventory = new();
        private statis List<Order> orders = new();

        //mock implementation
        internal static void IntializeStock() 
        {
           // inventory.Add(new Product(1, "Sugar","Lorem",new Price() {ItemPrice = 10, Currency
            //= Currency.Euro}, UnitType.PerKg, 100));

            ProductRepository productRepository = new();
            inventory = productRepository.LoadProductsFromFile();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Loaded {inventory.Count} products!");

            Console.WriteLine("Press enter to continue");

        }
    }
}