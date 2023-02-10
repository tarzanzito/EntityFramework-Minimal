
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EntityFrameworkMinimal.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        //public DateTime Validation { get; set; }
        public string Validation { get; set; }
        public int CategoryId { get; set; }

        //public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
