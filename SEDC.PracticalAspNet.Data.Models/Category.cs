using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEDC.PracticalAspNet.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public int MenuId { get; set; }

        public Menu Menu { get; set; }

        public List<Item> ListItems { get; set; }
    }
}
