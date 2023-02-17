﻿
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkMinimal.Models
{
    [Table("Categories")]
    public class Category
    {
       [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryGroupId { get; set; }
    }
}

