using System.Collections.Generic;

namespace CafeMVC.Web.Models
{
    public class OrderView
    {
        public List<Menu> MenuList {get; set;}


        public OrderView()
        {
            MenuList = new List<Menu>();
        }
    }
}
