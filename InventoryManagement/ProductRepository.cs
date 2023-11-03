using BethanyPieShop.InventoryManagement.Domain.General;
using BethanyPieShop.InventoryManagement.Domain.ProducManagement;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanyPieShop.InventoryManagement
{
    internal class ProductRepository
    {
        private string directory = @"C:\Nikita\Code\InventoryManagementSystem\";
        private string productFileName = "product.txt"; 

        //check for file
        private void CheckForFile()
        {
            string path = $"{directory}{productFileName}";

            bool existingFileFound = File.Exists(path);
            if(!existingFileFound)
            {
                //Create a new directory
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(directory);

                //Create empty file
                using FileStream fs = File.Create(path);
            }

        }

        public List<Domain.ProducManagement.Product> LoadProductsFromFile()
        {
            List<Domain.ProducManagement.Product> products = new List<Domain.ProducManagement.Product>();
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
                        out int maxItemInStock);

                    if(!success)
                    {
                        maxItemInStock = 100;
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
                            }, maxItemInStock, amountPerBox);
                    }
                     


                }
            }
        }

    }
}
