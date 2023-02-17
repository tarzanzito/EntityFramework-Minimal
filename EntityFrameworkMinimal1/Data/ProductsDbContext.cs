

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EntityFrameworkMinimal.Models;
using Microsoft.Extensions.Options;

namespace EntityFrameworkMinimal.Data
{
    internal sealed class ProductsDbContext : DbContext
    {
        public DbSet<CategoryGroup> CategoryGroups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        private readonly IConfiguration _configuration;

        public ProductsDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //logger
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()
                                                                     .AddDebug()
                                                                     .SetMinimumLevel(LogLevel.Debug)
                                                         ));
            // connect to sqlite database
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("MySqliteConnection"));

            base.OnConfiguring(optionsBuilder);
        }
    }
}





