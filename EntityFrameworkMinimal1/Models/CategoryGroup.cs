
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EntityFrameworkMinimal.Models
{
    [Table("CategoryGroups")]
    public class CategoryGroup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
