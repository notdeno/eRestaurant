using System.ComponentModel.DataAnnotations;

namespace SEDC.PracticalAspNet.Data.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }

        [Required]
        public short Quantity { get; set; }
    }
}
