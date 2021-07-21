using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class ListOfOrdersVm
    {
        public List<OrderForListVm> ListOfOrders { get; set; }

        public int Count { get; set; }
    }
}
    