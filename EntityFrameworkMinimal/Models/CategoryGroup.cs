
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EntityFrameworkMinimal.Models
{
    //public enum Grade
    //{
    //    A, B, C, D, F
    //}

    [Table("CategoryGroups")]
    public class CategoryGroup
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        //public Grade? Grade { get; set; }
        //public virtual Course Course { get; set; }
        //public virtual Student Student { get; set; }
    }
}
