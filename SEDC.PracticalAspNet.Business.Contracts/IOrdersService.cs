using SEDC.PracticalAspNet.Common.Contracts;
using System;

namespace SEDC.PracticalAspNet.Business.Contracts
{
    public interface IOrdersService : IService<DtoOrder>, IDisposable
    {
        ServiceResult<DtoOrderItem> SetOrderItem(DtoOrderItem orderItemDto);
    }
}