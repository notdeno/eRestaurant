using SEDC.PracticalAspNet.Data.Models;

namespace SEDC.PracticalAspNet.Common.Contracts
{
    public class DtoMenu
    {
        public DtoMenu()
        {

        }

        public DtoMenu(Menu menu)
        {
            Id = menu.Id;
            MenuName = menu.MenuName;
        }

        public int Id { get; set; }
        
        public string MenuName { get; set; }

    }
}
