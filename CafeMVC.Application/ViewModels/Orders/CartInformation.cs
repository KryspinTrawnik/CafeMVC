using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class CartInformation
    {
        public bool IsCollection  { get; set; }

        public int PaymentTypeId { get; set; }

        public string PaymentName { get; set; }

        public string Postcode { get; set; }
    }
}
