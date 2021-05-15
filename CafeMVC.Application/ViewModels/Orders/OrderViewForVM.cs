using System.Collections.Generic;

namespace CafeMVC.Web.Models
{
    public class OrderViewForVM
    {
        public List<MenuForListVM> MenuList {get; set;}


        public OrderViewForVM()
        {
            MenuList = new List<MenuForListVM>();
        }
    }
}
