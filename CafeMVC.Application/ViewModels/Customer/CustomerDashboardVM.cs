using CafeMVC.Application.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class CustomerDashboardVM
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public List<OrderForUserListVm > OrdersHistory { get; set; }
    }
}
