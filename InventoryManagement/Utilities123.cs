//using BethanyPieShop.InventoryManagement.Domain.General;
//using BethanyPieShop.InventoryManagement.Domain.OrderManagement;
//using BethanyPieShop.InventoryManagement.Domain.ProducManagement;
//using System;

//using System.Collections.Generic;
//using System.Linq;
//using System.Net.NetworkInformation;
//using System.Text;
//using System.Threading.Tasks;

//namespace BethanyPieShop.InventoryManagement
//{
//    internal class Utilities
//    {
//        //fields
//        private static List<Product> inventory = new();
//        private static List<Order> orders = new();

//        //methods
//        internal static void IntializeStock()
//        {
//            Product p1 = new Product(1, "Milk", "Goat milk", new Price() { ItemPrice = 10, Currency = Currency.Dollar }, UnitType.PerBox, 100);
//            Product p2 = new Product(2, "Butter", "Salted Butter", new Price() { ItemPrice = 20, Currency = Currency.Dollar }, UnitType.PerItem, 20);
//            inventory.Add(p1);
//            inventory.Add(p2);
//        }
//        internal static void ShowMainMenu()
//        {
//            Console.ResetColor();
//            Console.Clear();
//            Console.WriteLine("1: Select an action");
//            Console.WriteLine("2: Inventory Management");
//            Console.WriteLine("3: Order Management");
//            Console.WriteLine("4: Settings");
//            Console.WriteLine("5: Save all data");
//            Console.WriteLine("6: Close application");

//            Console.WriteLine("Your selection");

//            string? userSelection = Console.ReadLine();
//            switch (userSelection)
//            {
//                case "1":
//                    ShowInventoryManagementMenu();
//                    break;

//                case "2":
//                    ShowOrderManagementMenu();
//                    break;
//                case "3":
//                    ShowSettingsMenu();
//                    break;
//                case "4":
//                    //SaveAllData();
//                    break;

//                default:
//                    Console.WriteLine("Invalid selection");
//                    break;
//            }
//        }
//        private static void ShowInventoryManagementMenu()
//        {
//            string? userSelection;

//            do
//            {
//                Console.ResetColor();
//                Console.Clear();

//                ShowAllProductsOverview();

//                Console.WriteLine("1: View details of product");
//                Console.WriteLine("2: Add new product");
//                Console.WriteLine("3: Clone product");
//                Console.WriteLine("4: View Products with low stock");
//                Console.WriteLine("0: Go back to the main menu");

//                Console.Write("Your selection");

//                userSelection = Console.ReadLine();

//                switch (userSelection)
//                {
//                    case "1":
//                        ShowDetailsAndUseProduct();
//                        break;
//                    case "2": //ShowCreateNewProduct();
//                        break;
//                    case "3":
//                        //ShowCloneExistingProduct();
//                        break;
//                    case "4":
//                        ShowProductLowOnStock();
//                        break;
//                    default:
//                        Console.WriteLine("Invalid selection. Please try again");
//                        break;

//                }

//            }
//            while (userSelection != "0");

//        }

//        private static void ShowAllProductsOverview()
//        {
//            foreach (var product in inventory)
//            {
//                Console.WriteLine(product.DisplayDetailsShort());
//                Console.WriteLine();
//            }

//        }
//        private static void ShowDetailsAndUseProduct()
//        {
//            string? userSelection = string.Empty;
//            Console.Write("Enter product ID");
//            string? selectedProductId = Console.ReadLine();

//            if (selectedProductId != null)
//            {
//                Product? selectedProduct =
//                    inventory.Where(p => p.Id == int.Parse(selectedProductId)).FirstOrDefault();

//                if (selectedProduct != null)
//                {
//                    Console.WriteLine(selectedProduct.DisplayDetailsFull());
//                    Console.WriteLine("What do you wanna do ?");
//                    Console.WriteLine("1: Use Product");
//                    Console.Write("0 Back to invetory");

//                    Console.Write("Your selection");
//                    userSelection = Console.ReadLine();

//                    if (userSelection == "1")
//                    {
//                        Console.WriteLine("How many products do you want to use?");
//                        int amount = int.Parse(Console.ReadLine() ?? "0");

//                        selectedProduct.UseProduct(amount);
//                        Console.ReadLine();
//                    }

//                }
//            }
//            else
//                Console.WriteLine("Non existing product selected");
//        }

//        //    private static void ShowProductLowOnStock()
//        //    {
//        //        List<Product> lowOnStockProducts = inventory.Where(p => p.IsBelowStockThreshold).ToList();
//        //        if (lowOnStockProducts.Count > 0)
//        //        {
//        //            Console.WriteLine("The following items are low on stock, order more soon");

//        //            foreach (var product in lowOnStockProducts)
//        //            {
//        //                Console.WriteLine(product.DisplayDetailsShort());
//        //                Console.WriteLine();
//        //            }
//        //        }
//        //        else
//        //            Console.WriteLine("no items are currently in low stock");
//        //    }
//        //    //   Console.ReadLine();
//        //} 
//        private static void ShowOrderManagementMenu()
//        {
//            string? userSelection = string.Empty;
//            do
//            {
//                Console.ResetColor();
//                Console.Clear();
//                Console.WriteLine("********************");
//                Console.WriteLine("* Select an action *");
//                Console.WriteLine("********************");

//                Console.WriteLine("1: Open order overview");
//                Console.WriteLine("2: Add new order");
//                Console.WriteLine("0: Back to main menu");

//                Console.Write("Your selection: ");

//                userSelection = Console.ReadLine();

//                switch (userSelection)
//                {
//                    case "1":
//                        ShowOpenOrderOverview();
//                        break;
//                    case "2":
//                        ShowAddNewOrder();
//                        break;
//                    default:
//                        Console.WriteLine("Invalid selection. Please try again");
//                        break;
//                }

//            } while (userSelection != "0");
//            ShowMainMenu();
//        }
//        private static void ShowOpenOrderOverview()
//        {
//            ShowFulfilledOrders();

//            if (orders.Count > 0)
//            {
//                Console.WriteLine("Open orders");

//                foreach (var order in orders)
//                {
//                    Console.WriteLine(order.ShowOrderDetails());
//                    Console.WriteLine();
//                }
//            }
//            else
//            {
//                Console.WriteLine("there are no open orders");
//            }

//            Console.ReadLine();
//        }
//        private static void ShowFulfilledOrders()
//        {
//            Console.WriteLine("Checking fulfilled orders");
//            foreach (var order in orders)
//            {
//                //fulfill the order
//                if (!order.Fulfilled && order.OrderFulfilmentDate < DateTime.Now)
//                {
//                    foreach (var orderItem in order.OrderItems)
//                    {
//                        Product? selectedProduct = inventory.Where(p => p.Id == orderItem.ProductId).FirstOrDefault();
//                        if (selectedProduct != null)
//                            selectedProduct.IncreaseStock(orderItem.AmountOrdered);

//                    }
//                    order.Fulfilled = true;
//                }
//            }
//            orders.RemoveAll(o => o.Fulfilled);
//            Console.WriteLine("Fulfilled orders checked");
//        }
//        private static void ShowAddNewOrder()
//        {
//            Order newOrder = new Order();
//            string? selectedProductId = string.Empty;

//            Console.ForegroundColor = ConsoleColor.Yellow;
//            Console.WriteLine("Creating new order");
//            Console.ResetColor();

//            do
//            {
//                ShowAllProductsOverview();
//                Console.WriteLine("Which product do you want to order (Enter 0 if you want to stop adding orders");
//                Console.Write("Enter ID of product");
//                selectedProductId = Console.ReadLine();

//                if (selectedProductId != "0")
//                {
//                    Product? selectedProduct = inventory.Where(p => p.Id == int.Parse(selectedProductId)).FirstOrDefault();
//                    if (selectedProduct != null)
//                    {
//                        Console.WriteLine("How many do you want to order");
//                        int amountOrdered = int.Parse(Console.ReadLine() ?? "0");

//                        OrderItem orderItem = new OrderItem
//                        {

//                        }
//                    }
//                }
//            } while (selectedProductId != "0");
//            Console.WriteLine("Creating order");

//        }
//    }  

//    }

