using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class CustomerDetailsVm
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public List<AddressForListVm> AddressForListVm { get; set; }

        public List<ContactDetailForViewVm> ContactDetails { get; set; }
    }
}
