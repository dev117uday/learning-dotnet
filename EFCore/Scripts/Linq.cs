using System;
using System.Linq;
using EFCore.Data;
using EFCore.Models;

namespace EFCore
{
    class Program
    {
        static void Linq(string[] args)
        {
            using PgDBContext context = new PgDBContext();

            Products squeakyBone = new Products() { Name = "Dog Bone", Price = 10.99M };
            context.Products.Add(squeakyBone);
            
            Products tennisBall = new Products() { Name = "tennis ball pack", Price = 9.99M };
            context.Add(tennisBall);
            
            context.SaveChanges();

            var products = context.Products.Where(p => p.Price >= 5.00M).OrderBy(p => p.Name);
            
            foreach (var product in products)
            {
                Console.WriteLine($"Id : {product.Id}");
                Console.WriteLine($"Name : {product.Name}");
                Console.WriteLine($"Price : {product.Price}");
                Console.WriteLine("");
            }

            var squkyBone = context.Products
                .Where(p => p.Name == "Dog Bone").FirstOrDefault();
            
            if (squkyBone is Products)
            {
                squkyBone.Price = 4.99M;
            }
            
            context.SaveChanges();
            
            var productx = from product in context.Products
                where product.Price < 5.00m
                orderby product.Name
                select product;
            
            foreach (var product in productx)
            {
                Console.WriteLine($"Id : {product.Id}");
                Console.WriteLine($"Name : {product.Name}");
                Console.WriteLine($"Price : {product.Price}");
                Console.WriteLine("");
            }
            
            var squkyBone2 = context.Products
                .Where(p => p.Name == "Dog Bone").FirstOrDefault();

            if (squkyBone2 is Products)
            {
                context.Remove(squkyBone2);
            }

            context.SaveChanges();
            
            var producty = from product in context.Products
                orderby product.Name
                select product;
            
            foreach (var product in producty)
            {
                Console.WriteLine($"Id : {product.Id}");
                Console.WriteLine($"Name : {product.Name}");
                Console.WriteLine($"Price : {product.Price}");
                Console.WriteLine("");
            }

        }
    }
}
