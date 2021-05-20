using System;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class OrderForListVm
    {
        public int Id { get; set; }

        public DateTime DateOfOrder { get; set; }

        public string CustomerName { get; set; }

        public double TotalPrice { get; set; }
    }
}