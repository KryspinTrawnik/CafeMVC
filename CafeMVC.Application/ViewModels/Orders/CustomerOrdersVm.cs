using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class CustomerOrdersVm
    {
        public List<OrderForUserListVm> OrdersForUser { get; set; }
    }
}
