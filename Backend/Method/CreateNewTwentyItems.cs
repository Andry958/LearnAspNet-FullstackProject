using Backend.Model;
using System;
using System.Collections.Generic;

namespace Backend.Method
{
    public class CreateNewTwentyItems
    {
        public List<Product> AddProduct(List<Product> product_)
        {
            AddProducts(product_);

            foreach (var product in product_)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }
            return product_;
        }

        private void AddProducts(List<Product> products)
        {
            int id_ = products.Count + 1;
            string[] names = { "Laptop", "Smartphone", "Tablet", "Monitor", "Keyboard", "Mouse", "Headphones", "Smartwatch", "Printer", "Camera",
                               "Speaker", "Router", "SSD Drive", "HDD Drive", "USB Flash Drive", "Graphics Card", "Processor", "RAM Module", "Power Supply", "Cooling Fan" };

            Random random = new Random();
            for (int i = 0; i < names.Length; i++, id_++)
            {
                products.Add(new Product
                {
                    Id = id_,
                    Name = names[i],
                    Price = Math.Round((decimal)(random.Next(50, 500) + random.NextDouble()), 2)
                });
            }
        }
    }
}
