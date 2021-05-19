using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class OrderSummaryView
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public List<ProductForListVm> Products { get; set; }

        public AddressForOrderSummaryVm DeliveryAddress { get; set; }

        public DateTime DeliveryTime { get; set; }

    }
}
