
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EntityFrameworkMinimal.Models;
using System.Reflection.Emit;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EntityFrameworkMinimal.Data
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<CategoryGroup> CategoryGroups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        private readonly DbContextOptions<ProductsDbContext> _options;

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
            //IConfiguration _configuration = options.;

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
           .HasOne(s => s.CategoryGroup);
         //.WithMany(c => c.CategoryCollection);

    //     modelBuilder.Entity<CategoryGroup>()
    //.HasMany(c => c.CategoryCollection)
    //.WithOne(e => e.CategoryGroup);
        

         //.WithOne(ad => ad.Category)
         //.HasForeignKey<Category>(ad => ad.CategoryGroupId);
            
            // configures one-to-many relationship
            //modelBuilder.Entity<Category>().h
            //    //.HasRequired<CategoryGroup>(s => s.CurrentGrade)
            //    .WithMany(g => g.Students)
            //    .HasForeignKey<int>(s => s.CurrentGradeId);

            // modelBuilder.Entity<Category>().HasOne(a => a.CategoryGroup)
            //     .WithOne(b=>b.CategoryCollection)


            //.HasForeignKey<Category>(b => b..AuthorRef);
            // .HasRequired< Category(s => s..CurrentGrade)
            // .WithMany(g => g.Students)
            // .HasForeignKey<int>(s => s.CurrentGradeId);

            //modelBuilder.Entity<Category>()

            //    .HasOne<CategoryGroup>(p => p.CategoryGroup)
            //    .WithMany(b => b.CategoryCollection);
        }
    }
}
