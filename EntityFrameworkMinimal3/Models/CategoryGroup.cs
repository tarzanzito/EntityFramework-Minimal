
using EntityFrameworkMinimal.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EntityFrameworkMinimal.Models
{
    [Table("CategoryGroups")]
    public class CategoryGroup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Category> CategoryCollection { get; set; }

        public void Save()
        {
            var db = new ProductsDbContext(null);
            db.Add(this);
            db.SaveChanges();
        }

        public List<CategoryGroup> GetAll()
        {
            var db = new ProductsDbContext(null);
            return db.CategoryGroups.ToList();  
        }

    }
}
