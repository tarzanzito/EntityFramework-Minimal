
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
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

            using (var ctx = new ProductsDbContext(options))
            {
               // int noOfRowUpdated = ctx.Database.
                    //.sqlq...ExecuteSqlRaw("SELECT * FROM Products WHERE Id < 100");


            }

            using (var _context = new ProductsDbContext(options))
            {
                ////IEnumerable : make select WITHOUT WHERE and after make the filter
                //IEnumerable<CategoryGroup> categories1 = _context.CategoryGroups;
                //IEnumerable<CategoryGroup> enumerableFilter1 = categories1.Where(field => field.Id == 10);
                ////CategoryGroup[] array1 = enumerableFilter1.ToArray();   //here execute sql
                //List<CategoryGroup> list1 = enumerableFilter1.ToList(); //here execute sql again
                ////efective sqll: SELECT "c"."Id", "c"."CategoryGroupId", "c"."Name" FROM "Categories" AS "c"


                IQueryable<Category> categories = _context.Categories;
                IEnumerable<Category> enumerableFilter = categories.Where(field => field.Id == 10);
                List<Category> list = enumerableFilter.ToList(); //here execute sql again



                //IQueryable : make a select with WHERE
                IQueryable<CategoryGroup> categories2 = _context.CategoryGroups;
                IEnumerable<CategoryGroup> enumerableFilter2 = categories2.Where(field => field.Id == 10);
                //CategoryGroup[] array2 = enumerableFilter2.ToArray();   //here execute sql
                List<CategoryGroup> list2 = enumerableFilter2.ToList(); //here execute sql again
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
                //.AddInMemoryCollection()
                .Build();
//1-Settings files, such as appsettings.json
//2-Environment variables
//3-Azure Key Vault
//4-Azure App Configuration
//5-Command - line arguments
//6-Custom providers, installed or created
//7-Directory files
//8-In - memory.NET objects
//9-Third - party providers
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
    }
}

//MS-DOS
//yesh2__config1 = "config1Value"
//yesh2__config2 = "config2Value"
//=
//yesh2:
//  config1: "configValue1"
//  config2: "configValue2"


//var configuration = new ConfigurationBuilder().AddEnvironmentVariables("yesh2").Build();
//object obj =configuration.GetSection("yash2")
