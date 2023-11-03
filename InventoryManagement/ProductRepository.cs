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

        //public List<Domain.ProducManagement.Product> LoadProductFromFile()
        //{
        //    List<Domain.ProducManagement.Product> products = new List<Product>();

        //}

    }
}
