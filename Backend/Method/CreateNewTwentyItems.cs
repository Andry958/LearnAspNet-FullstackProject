using Backend.Model;
using Backend.Model.WorkWhitServer;
using System;
using System.Collections.Generic;

namespace Backend.Method
{
    public class CreateNewTwentyItems
    {
        private WorkWithServer _workWithServer;
        public CreateNewTwentyItems(WorkWithServer workWithServer)
        {
            _workWithServer = workWithServer;
        }
        public void AddProduct()
        {
            List<Product> products = new List<Product>();
            AddProducts(products);

            foreach (var product in products)
            {
                Console.WriteLine($"Name: {product.Name}, Price: {product.Price}");
            }

            _workWithServer.GetWorkWithServer().AddRange(products);
            _workWithServer.GetWorkWithServer().SaveChanges();
        }

        private void AddProducts(List<Product> products)
        {
            string[] names = { "Laptop", "Smartphone", "Tablet", "Monitor", "Keyboard", "Mouse", "Headphones", "Smartwatch", "Printer", "Camera",
                               "Speaker", "Router", "SSD Drive", "HDD Drive", "USB Flash Drive", "Graphics Card", "Processor", "RAM Module", "Power Supply", "Cooling Fan" };

            Random random = new Random();
            for (int i = 0; i < names.Length; i++)
            {
                products.Add(new Product
                {
                    Name = names[i],
                    Price = Math.Round((decimal)(random.Next(50, 500) + random.NextDouble()), 2)
                });
            }
        }
    }
}
