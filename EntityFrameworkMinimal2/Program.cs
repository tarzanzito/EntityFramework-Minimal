
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EntityFrameworkMinimal.Data;
using EntityFrameworkMinimal.Models;
using Microsoft.EntityFrameworkCore;


namespace EntityFrameworkMinimal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //load "appsettings.json" file
            IConfiguration configuration = SetupConfiguration(args);

            //load "ProductsDbContext" options
            DbContextOptions<ProductsDbContext> options = SetupProductsDbContextOptions(configuration);
          

            using (var _context = new ProductsDbContext(options))
            {
                //IEnumerable : make select WITHOUT WHERE and after make the filter
                IEnumerable<Category> categories1 = _context.Categories;
                IEnumerable<Category> enumerableFilter1 = categories1.Where(field => field.CategoryGroupId == 10);
                Category[] array1 = enumerableFilter1.ToArray();   //here execute sql
                List<Category> list1 = enumerableFilter1.ToList(); //here execute sql again
                //efective sqll: SELECT "c"."Id", "c"."CategoryGroupId", "c"."Name" FROM "Categories" AS "c"

                //IQueryable : make a select with WHERE
                IQueryable<Category> categories2 = _context.Categories;
                IEnumerable<Category> enumerableFilter2 = categories2.Where(field => field.CategoryGroupId == 10);
                Category[] array2 = enumerableFilter2.ToArray();   //here execute sql
                List<Category> list2 = enumerableFilter2.ToList(); //here execute sql again
                //efective sql: SELECT "c"."Id", "c"."CategoryGroupId", "c"."Name" FROM "Categories" AS "c" WHERE "c"."CategoryGroupId" = 10


                foreach (var product in list2)
                {
                    Console.WriteLine($"{product.Name} | {product.Id}");
                }
            }

            Console.ReadLine();
        }

        private static IConfiguration SetupConfiguration(string[] args)
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();
        }

        private static DbContextOptions<ProductsDbContext> SetupProductsDbContextOptions(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProductsDbContext>();

            //logger
            ILoggerFactory loggingBuilder = LoggerFactory.Create(builder => builder
                .AddConsole()
                .AddDebug()
                .SetMinimumLevel(LogLevel.Debug)
            );
            optionsBuilder.UseLoggerFactory(loggingBuilder);

            // connect to sqlite database
            optionsBuilder.UseSqlite(configuration.GetConnectionString("MySqliteConnection"));

            return optionsBuilder.Options;
        }


        //REF-01
        //DbContextOptions<ProductsDbContext> options = SetupDbContextOptionsB<ProductsDbContext>(configuration); //REF01
        private static DbContextOptions<T> SetupDbContextOptionsB<T>(IConfiguration configuration) where T : DbContext
        {
            var optionsBuilder = new DbContextOptionsBuilder<T>();
            return optionsBuilder.Options;
        }

        //REF-02
        //var produtcs = new Xpto();
        //DbContextOptions<Xpto> options2 = SetupDbContextOptionsC<Xpto>(produtcs); //REF02
        private static DbContextOptions<T> SetupDbContextOptionsC<T>(T t) where T : DbContext, new()
        {
            var temp1 = t; //t já é uma instancia de T
            var temp2 = new T(); 

            var optionsBuilder = new DbContextOptionsBuilder<T>();
            return optionsBuilder.Options;
        }
    
    }
}
