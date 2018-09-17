using SEDC.PracticalAspNet.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PracticalAspNet.Business.Model
{
    public class DtoMenu
    {
        public DtoMenu()
        {

        }

        public DtoMenu(Menu menu)
        {
            Id = menu.Id;
            TypeEnum = (MenuType)menu.TypeId;
            MenuName = menu.MenuName;
        }

        public int Id { get; set; }

        public MenuType TypeEnum { get; set; }

        public string MenuName { get; set; }

    }
}
