using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class OrderForUserListVm
    {
        public int Id { get; set; }

        public DateTime DateOfOrder { get; set; }

        public int ProductsCount { get; set; }
    }
}
