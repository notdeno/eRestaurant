using System.Collections.Generic;

namespace SEDC.PracticalAspNet.TestingServices
{
    public interface IItemsRepo
    {
        IEnumerable<string> GetItems();
    }
}
