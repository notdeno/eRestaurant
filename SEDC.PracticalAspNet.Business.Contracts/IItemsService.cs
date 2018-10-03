using SEDC.PracticalAspNet.Common.Contracts;
using SEDC.PracticalAspNet.Data.Contracts;
using System;

namespace SEDC.PracticalAspNet.Business.Contracts
{
    public interface IItemsService : IService<DtoItem>, IDisposable
    {
        ServiceResult<DtoItem> GetForCategory(int categoryId);
    }
}