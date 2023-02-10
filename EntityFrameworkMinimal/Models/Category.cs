
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkMinimal.Models
{
    [Table("Categories")]
    public class Category
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
       [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryGroupId { get; set; }

        //public ICollection<Enrollment> Enrollments { get; set; }
    }
}

