using SEDC.PracticalAspNet.Common.Contracts;
using SEDC.PracticalAspNet.Data.Repository;

namespace SEDC.PracticalAspNet.Business.Service
{
    public interface IItemsService: IBaseService<ItemsRepository>
    {
        ServiceResult<DtoItem> Add(DtoItem item);
        ServiceResult<DtoItem> Edit(DtoItem item);
        ServiceResult<DtoItem> GetForCategory(int categoryId);
        ServiceResult<DtoItem> Load(DtoItem item);
        ServiceResult<DtoItem> LoadAll();
        ServiceResult<DtoItem> Remove(DtoItem item);
    }
}