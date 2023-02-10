
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EntityFrameworkMinimal.Data;
using EntityFrameworkMinimal.Models;

//To read 
//https://stackify.com/net-core-loggerfactory-use-correctly/
//https://www.youtube.com/watch?v=zcTVRP7kKBY

namespace EntityFrameworkMinimal
{
    public class Program
    {
        //First Unzip "EntityFrameworkMinimal\Sqlite_Database\\DB-Products_no_indexes.zip.001"
        public static void Main(string[] args)
        {
            ////https://emanuelpaul.net/2019/06/03/console-app-with-configuration-dependency-injection-and-logging/
            ////Todo: try for automatic depend injection process in DataContext
            //ServiceProvider serviceProvider = RegisterServices(args);
            //IConfiguration configuration = serviceProvider.GetService<IConfiguration>();

            //load "appsettings.json" file
            IConfiguration configuration = SetupConfiguration(args);


            using (var _context = new MyDataContext(configuration))
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

        private static ServiceProvider RegisterServices(string[] args)
        {
            IConfiguration configuration = SetupConfiguration(args);
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddLogging(cfg => cfg.AddConsole());
            serviceCollection.AddSingleton(configuration);

            return serviceCollection.BuildServiceProvider();
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
    }
}
//https://azurelessons.com/error-cs1061-iconfigurationbuilder-does-not-contain-definition-for-addenvironmentvariables/
//secrets


//https://docs.datalust.co/docs/microsoft-extensions-logging