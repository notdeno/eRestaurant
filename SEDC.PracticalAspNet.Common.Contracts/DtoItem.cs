using SEDC.PracticalAspNet.Data.Models;

namespace SEDC.PracticalAspNet.Common.Contracts
{
    public class DtoItem
    {
        public DtoItem()
        {

        }
        public DtoItem(Item result)
        {
            Id = result.Id;
            CategoryId = result.CategoryId;
            Name = result.Name;
            Description = result.Description;
            Contents = result.Contents;
            Price = result.Price;
            Availability = result.Availability;
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contents { get; set; }
        public double Price { get; set; }
        public bool Availability { get; set; }
    }
}
