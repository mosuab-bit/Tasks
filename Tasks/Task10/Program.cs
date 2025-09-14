using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Contexts;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static Task10.Program;

namespace Task10
{
    internal class Program
    {
        //        Task: Implement Pagination with "Last Product Id" Technique
        //Provided:
        //You are given the following Entity Class and AppDbContext declaration:
        //// Entity Class
        //public class Product
        //        {
        //            public int Id { get; set; }
        //            public string Name { get; set; } = string.Empty;
        //            public decimal Price { get; set; }
        //            public DateTime CreatedAt { get; set; }
        //        }
        //        // AppDbContext
        //        public class AppDbContext : DbContext
        //        {
        //            public DbSet<Product> Products { get; set; }
        //            public AppDbContext(DbContextOptions<AppDbContext> options) :
        //           base(options)
        //            { }
        //        }
        //        Task Requirements:
        //1. Write a function GetProductsPageAsync that:
        //o Accepts:
        // int? lastProductId → the last product Id from the previous
        //page(or null if first page).
        // int limit = 8 → maximum number of products per page
        //(default 8).
        //o Returns:
        // A list of the next products, ordered by Id.
        //2. Use the "Last Product Id" pagination technique.
        //3. Products should be ordered by Id ascending.

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop",   Price = 750.00m, CreatedAt = DateTime.Now.AddDays(-10) },
            new Product { Id = 2, Name = "Mouse",    Price = 25.50m,  CreatedAt = DateTime.Now.AddDays(-8) },
            new Product { Id = 3, Name = "Keyboard", Price = 45.00m,  CreatedAt = DateTime.Now.AddDays(-5) },
            new Product { Id = 4, Name = "Monitor",  Price = 200.00m, CreatedAt = DateTime.Now.AddDays(-3) },
            new Product { Id = 5, Name = "Headset",  Price = 80.00m,  CreatedAt = DateTime.Now },
            new Product { Id = 6, Name = "Keyboard", Price = 45.00m,  CreatedAt = DateTime.Now.AddDays(-5) },
            new Product { Id = 7, Name = "Monitor",  Price = 200.00m, CreatedAt = DateTime.Now.AddDays(-3) },
            new Product { Id = 8, Name = "Headset",  Price = 80.00m,  CreatedAt = DateTime.Now }
        };

        public static List<Product> GetProductPage(int? lastProductId,int limit = 8)
        {
            if (limit <= 0) limit = 8;

            IEnumerable<Product> query = products.OrderBy(p => p.Id);

            if (lastProductId.HasValue)
                query = query.Where(p => p.Id > lastProductId.Value);

            return query.Take(limit).ToList();


        }
        static void Main(string[] args)
        {
            var pro = GetProductPage(3,3);

            foreach (var item in pro)
                Console.WriteLine(item.Name);
        }
    }
}
