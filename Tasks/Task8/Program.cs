using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    internal class Program
    {
        //Problem-Solving Question: Find the Most Expensive Product Scenario:
        //You're building a simple e-commerce app, and you receive an array of product objects from the backend
        //. Each product has a name and a price. You need to write a JavaScript function that returns the name of
        //the most expensive product. Input Example: const products = [ { name: "T-shirt", price: 25 },
        //{ name: "Sneakers", price: 80 }, { name: "Jeans", price: 50 }, { name: "Jacket", price: 120 } ];
        //Expected Output: getMostExpensiveProduct(products); 
        // ➞ "Jacket" ✅ Requirements: 1. Write a function getMostExpensiveProduct(products).
        // 2. It should return only the name of the most expensive product.
        // 3. Assume all prices are positive numbers. • What if there are multiple products with the same highest price?
        // Return all their names in an array.

        public class Product
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }

        private static List<Product> products = new List<Product>
        {
            new Product
            {
               Name = "T-Shirt",
               Price = 25
            },
            new Product {
               Name = "Sneakers",
               Price = 80
            },
            new Product {
               Name = "Jeans",
               Price = 50
            },
            new Product {
               Name = "Jacket",
               Price = 120
            },
            new Product
            {
                Name = "Shoes",
                Price = 120
            }
        };

        public static List<string> getMostExpensiveProduct(List<Product> products)
        {

            double maxPrice = products.Max(p => p.Price);
            
            return products.Where(p=>p.Price ==  maxPrice).
                   Select(p => p.Name).ToList();
        }
        static void Main(string[] args)
        {
            var result = getMostExpensiveProduct(products);

            if (result.Count == 1)
                Console.WriteLine(result[0]);
            else
                Console.WriteLine(string.Join(",",result));
        }
    }
}
