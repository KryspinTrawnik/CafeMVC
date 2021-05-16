using System;
using System.Collections.Generic;

namespace CafeMVC.Web.Models
{
    public class OrderViewForVM
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public double TotalPrice { get; set; }

        public List<ProductForListVM> OrderedProduct { get; set; }

        public DateTime DateOfOrder { get; set; }

        public string DeliveryAddress { get; set; }

    }
}
