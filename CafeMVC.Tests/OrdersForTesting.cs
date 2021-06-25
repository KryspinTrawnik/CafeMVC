using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Tests
{
    public class OrdersForTesting
    {
        public List<Order> OrdersOfCustomersOne()
        {
            List<Order> ListOfOrdersCustomerOne = new List<Order>();

            Order order1Customer1 = new Order()
            {
                Id = 1,
                DateOfOrder = new DateTime(2021, 06, 30, 8, 0, 0),
                LeadTime = new DateTime(2021, 06, 30, 10, 0, 0),
                Products = new List<Product>(),
                OrderConfirmation =
            };


        }
    }
}
