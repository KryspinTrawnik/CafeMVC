using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class ListOfCustomers
    {
        public List<CustomerForListVm> ListOfAllCustomers { get; set; }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public string SearchString { get; set; }

        public int Count { get; set; }
    }
}
