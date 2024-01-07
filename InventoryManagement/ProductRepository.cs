using InventoryManagement.Domain.Contracts;
using InventoryManagement.Domain.General;
using InventoryManagement.Domain.ProductManagement;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
   internal class ProductRepository
   {
       private string directory = @"C:\Nikita\Code\InventoryManagementSystem\";
       private string productFileName = "product.txt";
       private string productsSaveFileName = "products2.txt";


       //check for file
       private void CheckForFile()
       {
           string path = $"{directory}{productFileName}";

           bool existingFileFound = File.Exists(path);
           if (!existingFileFound)
           {
               //Create a new directory
               if (!Directory.Exists(path))
                   Directory.CreateDirectory(directory);

               //Create empty file
               using FileStream fs = File.Create(path);
           }

       }

       public List<Product> LoadProductsFromFile()
       {
           List<Product> products = new List<Product>();
           string path = $"{directory}{productFileName}";
           try
           {
               CheckForFile();
               string[] productAsString = File.ReadAllLines(path);
               for (int i = 0; i < productAsString.Length; i++)
               {
                   string[] productSplits = productAsString[i].Split(';');
                   bool success = int.TryParse(productSplits[0],
                       out int productId);
                   if (!success)
                   {
                       productId = 0; //set default value
                   }
                   string name = productSplits[1];
                   string description = productSplits[2];

                   success = int.TryParse(productSplits[3],
                       out int maxItemsInStock);

                   if (!success)
                   {
                       maxItemsInStock = 100;
                   }

                   success = int.TryParse(productSplits[4],
                       out int itemPrice);

                   if (!success)
                   {
                       itemPrice = 0;
                   }

                   success = Enum.TryParse(productSplits[5],
                       out Currency currency);

                   if (!success)
                   {
                       currency = Currency.Dollar;
                   }

                   success = Enum.TryParse(productSplits[6],
                       out UnitType unitType);

                   string productType = productSplits[7];

                   Product product = null;

                   switch (productType)
                   {
                       case "1":
                           success = int.TryParse(productSplits[8],
                               out int amountPerBox);
                           if (!success)
                           {
                               amountPerBox = 1;
                           }
                           product = new BoxedProduct(productId, name, description, new Price()
                           {
                               ItemPrice = itemPrice,
                               Currency = currency
                           }, 
                           maxItemsInStock, amountPerBox);
                           break;

                           case "2":
                            product = new FreshProduct(productId, name, description, new Price() { ItemPrice = itemPrice, Currency = currency }, unitType, maxItemsInStock);
                            break;
                            
                           case "3":
                            product = new BulkProduct(productId, name, description, new Price() { ItemPrice = itemPrice, Currency = currency }, maxItemsInStock);
                            break;

                            case "4":
                            product = new RegularProduct(productId, name, description,
                            new Price() {ItemPrice = itemPrice, Currency = currency}, unitType,
                            maxItemsInStock);
                            break;
                   }
                   
                   products.Add(product);

               }
           }

           catch (IndexOutOfRangeException iex)
           {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong while parsing the file. Please check the file again");
                Console.WriteLine(iex.Message);
           }
           catch (FileNotFoundException fnfex)
           {
             Console.ForegroundColor = ConsoleColor.Red;
             Console.WriteLine("File couldnt be found");

           }
           catch (Exception ex)
           {
             Console.ForegroundColor = ConsoleColor.Red;
             Console.WriteLine("Something went wrong will loading the file");
             Console.WriteLine(ex.Message);
           }
           finally 
           {
                Console.ResetColor();
           }
           return products;
       }

       public void SaveToFile(List<ISaveable> saveables)
       {
         StringBuilder sb = new StringBuilder();
         string path = $"{directory}{productsSaveFileName}";

         foreach(var item in saveables)
         {
            sb.Append(item.ConvertToStringForSaving());
            sb.Append(Environment.NewLine);
         }
         File.WriteAllText(path, sb.ToString());

         Console.ForegroundColor = ConsoleColor.Green;
         Console.WriteLine("Saved items successfully");
         Console.ResetColor();
       }

   }
}
