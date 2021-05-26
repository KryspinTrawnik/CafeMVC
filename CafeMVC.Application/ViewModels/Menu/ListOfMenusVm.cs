using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Menu
{
    public class ListOfMenusVm
    {
        public List<MenuForListVM> ListOfAllMenus { get; set; }

        public int Count { get; set; }
    }
}
