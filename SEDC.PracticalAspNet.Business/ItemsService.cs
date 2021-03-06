﻿using SEDC.PracticalAspNet.Business.Contracts;
using SEDC.PracticalAspNet.Common.Contracts;
using SEDC.PracticalAspNet.Data.Models;
using SEDC.PracticalAspNet.Data.Repository;
using System;
using System.Linq;

namespace SEDC.PracticalAspNet.Business.Service
{
    public class ItemsService : BaseService<ItemsRepository>, IItemsService, IService<DtoItem>, IDisposable
    {
        public ServiceResult<DtoItem> Add(DtoItem item)
        {
            var categoryExists = DbContext
                .Categories
                .Any(c => c.Id == item.CategoryId);
            if (!categoryExists)
            {
                return new ServiceResult<DtoItem>
                {
                    Success = false,
                    ErrorMessage = "3404"
                };
            }
            var newItem = new Item
            {
                Id = 0,
                Name = item.Name,
                Availability = item.Availability,
                CategoryId = item.CategoryId,
                Contents = item.Contents,
                Description = item.Description,
                Price = item.Price
            };
            var result = Repository.Create(newItem);
            return new ServiceResult<DtoItem>()
            {
                Success = true,
                Item = new DtoItem(result)
            };
        }

        public ServiceResult<DtoItem> GetForCategory(int categoryId)
        {
            var exists = DbContext.Categories.Any(x => x.Id == categoryId);
            if (!exists)
            {
                return new ServiceResult<DtoItem>
                {
                    ErrorMessage = "Category not found"
                };
            }
            var dbItems = DbContext.Items.Where(x => x.CategoryId == categoryId).ToList();
            return new ServiceResult<DtoItem>
            {
                Success = true,
                ListItems = dbItems.Select(x => new DtoItem(x)).ToList()
            };
        }

        public ServiceResult<DtoItem> Edit(DtoItem item)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoItem> Load(DtoItem item)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoItem> LoadAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoItem> Remove(DtoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
