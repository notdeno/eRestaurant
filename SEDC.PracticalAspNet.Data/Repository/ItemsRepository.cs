using SEDC.PracticalAspNet.Data.Contracts;
using SEDC.PracticalAspNet.Data.Models;
using System;
using System.Collections.Generic;

namespace SEDC.PracticalAspNet.Data.Repository
{
    public class ItemsRepository : BaseRepository, IRepository<Item>, IItemsRepository
    {
        public Item Create(Item item)
        {
            item.Id = default(int);
            item.Name = item.Name.Trim();
            DbContext.Set<Item>().Add(item);
            int rowsAffected = DbContext.SaveChanges();
            return item;
        }

        public void Delete(Item item)
        {
            throw new NotImplementedException();
        }

        public Item Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Item> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
