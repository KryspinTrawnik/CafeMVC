using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
