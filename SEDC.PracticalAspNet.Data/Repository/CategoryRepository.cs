using System;
using System.Collections.Generic;
using SEDC.PracticalAspNet.Data.Models;

namespace SEDC.PracticalAspNet.Data.Repository
{
    public class CategoryRepository : BaseRepository, IRepository<Category>
    {
        public Category Create(Category item)
        {
            DbContext.Categories.Add(item);
            DbContext.SaveChanges();
            return item;
        }

        public void Delete(Category item)
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
