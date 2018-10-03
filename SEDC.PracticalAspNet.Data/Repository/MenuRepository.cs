using System.Linq;
using System.Collections.Generic;
using SEDC.PracticalAspNet.Data.Models;
using SEDC.PracticalAspNet.Data.Contracts;

namespace SEDC.PracticalAspNet.Data.Repository
{
    public class MenuRepository :
        BaseRepository, IRepository<Menu>, IMenuRepository
    {
        public Menu Create(Menu item)
        {
            DbContext.Menus.Add(item);
            DbContext.SaveChanges();
            return item;
        }

        public void Delete(Menu item)
        {
            var dbItem = DbContext.Menus.Single(m => 
                m.Id == item.Id);
            DbContext.Menus.Remove(dbItem);
            DbContext.SaveChanges();
        }

        public Menu Get(int id)
        {
            return DbContext.Menus.SingleOrDefault(
                m => m.Id == id);
        }

        public IList<Menu> GetAll()
        {
            return DbContext.Menus.ToList();
        }

        public void Update(Menu item)
        {
            var dbMenu = DbContext.Menus.FirstOrDefault(m => 
                m.Id == item.Id);
            
            dbMenu.MenuName = item.MenuName;
            DbContext.SaveChanges();
        }
    }
}
