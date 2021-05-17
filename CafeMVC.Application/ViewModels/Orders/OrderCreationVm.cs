using CafeMVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class OrderCreationVm
    {
        public int Id { get; set; }

        public string Note { get; set; }

        public int OrderConfirmation { get; set; }

        public bool IsCollection { get; set; }

        public int CustomerId { get; set; }

        public List<AddressVm> Addresses { get; set; }

        public List<ProductForListVm> MyProperty { get; set; }
    }
}
