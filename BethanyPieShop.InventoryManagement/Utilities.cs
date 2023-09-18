﻿using BethanyPieShop.InventoryManagement.Domain.General;
using BethanyPieShop.InventoryManagement.Domain.ProducManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanyPieShop.InventoryManagement
{
    internal class Utilities
    {
        //fields
        private static List<Product> inventory = new();
        private static List<Order> orders = new();

        //methods
        internal static void IntializeStock()
        {
            Product p1 = new Product(1, "Milk", "Goat milk", new Price() { ItemPrice = 10, Currency = Currency.Dollar }, UnitType.PerBox, 100);
            Product p2 = new Product(2, "Butter", "Salted Butter", new Price() { ItemPrice = 20, Currency = Currency.Dollar }, UnitType.PerItem, 20);
            inventory.Add(p1);
            inventory.Add(p2);
        }
        internal static void ShowMainMenu()
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("1: Select an action");
            Console.WriteLine("2: Inventory Management");
            Console.WriteLine("3: Order Management");
            Console.WriteLine("4: Settings");
            Console.WriteLine("5: Save all data");
            Console.WriteLine("6: Close application");

            Console.WriteLine("Your selection");

            string? userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "1":
                    ShowInventoryManagementMenu();
                    break;

                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;

            }
        }
            private static void ShowInventoryManagementMenu()
            {
                string? userSelection;

            do
            {
                Console.ResetColor();
                Console.Clear();

                ShowAllProductsOverview();

                Console.WriteLine("1: View details of product");
                Console.WriteLine("2: Add new product");
                Console.WriteLine("3: Clone product");
                Console.WriteLine("4: View Products with low stock");
                Console.WriteLine("0: Go back to the main menu");

                Console.Write("Your selection");

                userSelection = Console.ReadLine();

                switch(userSelection)
                {
                    case "1":
                        ShowDetailsAndUseProduct();
                        break;
                    case "2": //ShowCreateNewProduct();
                        break;
                    case "3":
                        //ShowCloneExistingProduct();
                        break;
                    case "4":
                        ShowProductLowOnStock();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again");
                        break;

                }

            }
            while (userSelection != "0");
                
             }

            private static void ShowAllProductsOverview()
            {   
                foreach (var product in inventory)
            {
                Console.WriteLine(product.DisplayDetailsShort());
                Console.WriteLine();
            }

            }
        private static void ShowDetailsAndUseProduct()
        {
            string? userSelection = string.Empty;
            Console.Write("Enter product ID");
            string? selectedProductId = Console.ReadLine();

            if (selectedProductId != null)
            {
                Product? selectedProduct =
                    inventory.Where(p => p.Id == int.Parse(selectedProductId)).FirstOrDefault();

                if (selectedProduct != null)
                {
                    Console.WriteLine(selectedProduct.DisplayDetailsFull());
                    Console.WriteLine("What do you wanna do ?");
                    Console.WriteLine("1: Use Product");
                    Console.Write("0 Back to invetory");

                    Console.Write("Your selection");
                    userSelection = Console.ReadLine();

                    if (userSelection == "1")
                    {
                        Console.WriteLine("How many products do you want to use?");
                        int amount = int.Parse(Console.ReadLine() ?? "0");

                        selectedProduct.UseProduct(amount);
                        Console.ReadLine();
                    }

                }
            }
            else
                Console.WriteLine("Non existing product selected");
        }

        private static void ShowProductLowOnStock()
        {
            List<Product> lowOnStockProducts = inventory.Where(p => p.IsBelowStockThreshold).ToList();
            if (lowOnStockProducts.Count > 0)
            {
                Console.WriteLine("The following items are low on stock, order more soon");

                foreach (var product in lowOnStockProducts)
                {
                    Console.WriteLine(product.DisplayDetailsShort());
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("no items are currently in low stock");
        }
        }
    }
}