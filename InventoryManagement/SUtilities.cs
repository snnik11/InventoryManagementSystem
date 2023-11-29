using InventoryManagement.Domain.Contracts;
using InventoryManagement.Domain.General;
using InventoryManagement.Domain.OrderManagement;
using InventoryManagement.Domain.ProductManagement;

namespace InventoryManagement
{
    internal class Utilities
    {
        private static List<Product> inventory = new();
        private static List<Order> orders = new();

        internal static void InitializeStock()
        {
            ProductRepository productRepository = new();
            inventory = productRepository.LoadProductsFromFile();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Loaded {inventory.Count} products! ");

            Console.WriteLine("Press enter to continue");
            Console.ResetColor();

            Console.ReadLine();
        }

        internal static void ShowMainMenu()
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("1: Inventory management");
            Console.WriteLine("2: Order management");
            Console.WriteLine("3: Settings");
            Console.WriteLine("4: Save all data");
            Console.WriteLine("0: Close application");

            Console.Write("Your selection: ");

            string? userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "1":
                    ShowInventoryManagementMenu();
                break;

                case "2": 
                    ShowOrderManagementMenu();
                break;

                case "3":
                    ShowSettingsMenu();
                break;

                case "4":
                    SaveAllData();
                break;

                default: 
                Console.WriteLine("Invalid selection");
                break;
            }
        }

        private 
    }
}
