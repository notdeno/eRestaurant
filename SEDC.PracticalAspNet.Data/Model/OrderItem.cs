using System.ComponentModel.DataAnnotations;

namespace SEDC.PracticalAspNet.Data.Model
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }

        [Required]
        public short Quantity { get; set; }
    }
}
