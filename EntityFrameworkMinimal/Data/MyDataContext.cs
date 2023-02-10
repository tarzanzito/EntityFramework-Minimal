

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EntityFrameworkMinimal.Models;

namespace EntityFrameworkMinimal.Data
{
    public class MyDataContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public MyDataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //logger
            options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()
                                                                     .AddDebug()
                                                                     .SetMinimumLevel(LogLevel.Debug)
                                                         ));
            // connect to sqlite database
            options.UseSqlite(_configuration.GetConnectionString("MySqliteConnection"));
        }

        public DbSet<CategoryGroup> CategoryGroups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        //Todo: understand this example
        public MyDataContext(DbContextOptions<MyDataContext> options) : base(options)
        {
        }
    }
}





