using System.Collections.Generic;

namespace SEDC.PracticalAspNet.TestingServices
{
    public class ItemsRepo : IItemsRepo
    {
        public IEnumerable<string> GetItems()
        {
            return new List<string>
            {
                "value-one",
                "value-two",
                "value-three"
            };
        }
    }
}
