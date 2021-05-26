using CafeMVC.Application.ViewModels.Orders;
using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class CustomerForDashboardVm
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public List<OrderForUserListVm > OrdersHistory { get; set; }
    }
}
