using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEDC.PracticalAspNet.Data.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string MenuName { get; set; }
        
        public virtual List<Category> ListCategories { get; set; }
    }
}
