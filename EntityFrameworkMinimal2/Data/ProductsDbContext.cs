
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EntityFrameworkMinimal.Models;

namespace EntityFrameworkMinimal.Data
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<CategoryGroup> CategoryGroups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        private DbContextOptions<ProductsDbContext> _options;

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
            //IConfiguration _configuration = options.;
            _options = options;
        }
    }
}
