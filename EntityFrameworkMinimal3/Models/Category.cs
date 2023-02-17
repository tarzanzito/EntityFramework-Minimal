
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EntityFrameworkMinimal.Models
{
    [Table("Categories")]
    public class Category
    {
       [Key]
        public int Id { get; set; }
        public string Name { get; set; }

       [ForeignKey("CategoryGroup")]
        public int CategoryGroupId { get; set; }
        public virtual CategoryGroup CategoryGroup { get; set; }
        //public virtual ICollection<Product> ProductCollection { get; set; }
    }
}

