using SEDC.PracticalAspNet.Common.Contracts;

namespace SEDC.PracticalAspNet.Business.Contracts
{
    public interface ICategoryService : IService<DtoCategory>
    {
        ServiceResult<DtoCategory> LoadForMenu(int menuId);
    }
}