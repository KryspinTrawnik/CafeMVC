using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class CustomerForCreationVm
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public List<AddressForCreationVm> Addresses{ get; set; }

        public List<ContactDetailForViewVm> ContactDetails { get; set; }
    }
}
