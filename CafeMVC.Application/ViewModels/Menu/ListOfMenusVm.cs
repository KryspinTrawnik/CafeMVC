using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Menu
{
    public class ListOfMenusVm
    {
        public List<MenuForListVm> ListOfAllMenus { get; set; }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public string SearchString { get; set; }

        public int Count { get; set; }
    }
}
