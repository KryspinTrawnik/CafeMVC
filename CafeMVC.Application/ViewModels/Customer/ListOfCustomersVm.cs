using CafeMVC.Application.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class ListOfCustomersVm
    {
        public List<CustomerForListVm> ListOfCustomers { get; set; }

        public int Count { get; set; }
    }
}
                    