using CafeMVC.Application.ViewModels.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class AdminDashboardVm
    {
        public List<OrderForListVm> ListOfOpenOrders { get; set; }

        public List<MenuForListVm> ListOfOpenMenus { get; set; }
    }
}
