using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class CustomerContactDetails
    {
        public int CustomerId { get; set; }

        public List<CustomerContactInfoForViewVm> Emails { get; set; }

        public List<CustomerContactInfoForViewVm> PhoneNumbers { get; set; }
    }
}
