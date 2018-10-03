using SEDC.PracticalAspNet.Common.Contracts;
using SEDC.PracticalAspNet.Data.Models;
using SEDC.PracticalAspNet.Data.Repository;
using System;
using System.Linq;

namespace SEDC.PracticalAspNet.Business.Service
{
    public class CategoryService : BaseService<CategoryRepository>, IService<DtoCategory>
    {
        public ServiceResult<DtoCategory> Add(DtoCategory item)
        {
            //Repository.DbContext.Set<>
            var menuExists = Repository.DbContext.Menus.Any(x => x.Id == item.MenuId);
            if (!menuExists)
                return new ServiceResult<DtoCategory>
                {
                    Success = false,
                    ErrorMessage = "2404"
                };
            
            var newCategory = new Category
            {
                Id = 0,
                Name = item.CategoryName,
                MenuId = item.MenuId
            };
            var result = Repository.Create(newCategory);
            return new ServiceResult<DtoCategory>()
            {
                Success= true,
                Item = new DtoCategory(result)
            };
        }

        public ServiceResult<DtoCategory> LoadForMenu(int menuId)
        {
            if (!Repository.DbContext.Menus.Any(x => x.Id == menuId))
                return new ServiceResult<DtoCategory>
                {
                    Success = false,
                    ErrorMessage = "menu not found"
                };
            var categories = Repository.DbContext.Categories.Where(x => x.MenuId == menuId).ToList();
            return new ServiceResult<DtoCategory>
            {
                Success = true,
                ListItems = categories.Select(x => new DtoCategory(x)).ToList()
            };
        }

        public ServiceResult<DtoCategory> Edit(DtoCategory item)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoCategory> Load(DtoCategory item)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoCategory> LoadAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoCategory> Remove(DtoCategory item)
        {
            throw new NotImplementedException();
        }
    }
}
