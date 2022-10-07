using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class ListsOfOrdersForIndexVm
    {
        public List<OrderForListVm> ListOfOpenOrders { get; set; }

        public List<OrderForListVm> ListOfClosedOrders { get; set; }

    }
}
    