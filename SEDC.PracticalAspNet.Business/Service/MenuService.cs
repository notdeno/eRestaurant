using System;
using System.Collections.Generic;
using System.Linq;
using SEDC.PracticalAspNet.Common.Contracts;
using SEDC.PracticalAspNet.Data.Models;
using SEDC.PracticalAspNet.Data.Repository;

namespace SEDC.PracticalAspNet.Business.Service
{
    public class MenuService : BaseService<MenuRepository>, IService<DtoMenu>
    {
        public ServiceResult<DtoMenu> Add(DtoMenu item)
        {
            try
            {
                var result = Repository.Create(new Menu()
                {
                    MenuName = item.MenuName
                });
                return new ServiceResult<DtoMenu>()
                {
                    Item = new DtoMenu(result),
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoMenu>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoMenu> Edit(DtoMenu item)
        {
            try
            {
                if ((item?.Id ?? 0) > 0)
                {
                    var dbMenu = Repository.Get(item.Id);
                    if (dbMenu == null)
                        return new ServiceResult<DtoMenu>
                        {
                            Success = false,
                            ErrorMessage = "menu not found"
                        };
                    Repository.Update(new Menu
                    {
                        Id = item.Id,
                        MenuName = item.MenuName
                    });
                    return new ServiceResult<DtoMenu>
                    {
                        Success = true,
                        Item = new DtoMenu(dbMenu)
                    };
                }
                return new ServiceResult<DtoMenu>
                {
                    Success = false,
                    ErrorMessage = "id is required parameter"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<DtoMenu>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoMenu> Load(DtoMenu item)
        {
            if ((item?.Id ?? 0) < 1)
            {
                return new ServiceResult<DtoMenu>
                {
                    Success = false,
                    ErrorMessage = "id is a required parameter"
                };
            }

            try
            {
                var dbItem = Repository.Get(item.Id);
                if (dbItem == null)
                    return new ServiceResult<DtoMenu>
                    {
                        Success = false,
                        ErrorMessage = "menu not found"
                    };

                return new ServiceResult<DtoMenu>
                {
                    Success = true,
                    Item = new DtoMenu(dbItem)
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<DtoMenu>
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoMenu> LoadAll()
        {
            try
            {
                var menus = Repository.GetAll().ToList();
                var resultList = new List<DtoMenu>();
                menus.ForEach(m => resultList.Add(new DtoMenu(m)));
                return new ServiceResult<DtoMenu>()
                {
                    ListItems = resultList,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoMenu>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoMenu> Remove(DtoMenu item)
        {
            throw new NotImplementedException();
        }
    }
}
