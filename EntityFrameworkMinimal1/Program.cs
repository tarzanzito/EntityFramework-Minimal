
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EntityFrameworkMinimal.Data;
using EntityFrameworkMinimal.Models;


namespace EntityFrameworkMinimal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //load "appsettings.json" file
            IConfiguration configuration = SetupConfiguration(args);

            using (var productsDbContext = new ProductsDbContext(configuration))
            {
                //IEnumerable : make select WITHOUT WHERE and after make the filter
                IEnumerable<Category> categories1 = productsDbContext.Categories;
                IEnumerable<Category> enumerableFilter1 = categories1.Where(field => field.CategoryGroupId == 10);
                Category[] array1 = enumerableFilter1.ToArray();   //here execute sql
                List<Category> list1 = enumerableFilter1.ToList(); //here execute sql again
                //efective sqll: SELECT "c"."Id", "c"."CategoryGroupId", "c"."Name" FROM "Categories" AS "c"

                //IQueryable : make a select with WHERE
                IQueryable<Category> categories2 = productsDbContext.Categories;
                IEnumerable<Category> enumerableFilter2 = categories2.Where(field => field.CategoryGroupId == 10);
                Category[] array2 = enumerableFilter2.ToArray();   //here execute sql
                List<Category> list2 = enumerableFilter2.ToList(); //here execute sql again
                //efective sql: SELECT "c"."Id", "c"."CategoryGroupId", "c"."Name" FROM "Categories" AS "c" WHERE "c"."CategoryGroupId" = 10

                foreach (var product in list1)
                {
                    Console.WriteLine($" {product.Id} | {product.Name}");
                }
            }

            Console.ReadLine();
        }

        private static IConfiguration SetupConfiguration(string[] args)
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
