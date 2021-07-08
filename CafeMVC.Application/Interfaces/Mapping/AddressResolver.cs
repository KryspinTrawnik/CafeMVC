using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.Interfaces.Mapping
{
    public class AddressResolver : IValueResolver<Address, AddressDetailsForViewVm, string>
    {
        public string Resolve(Address source, AddressDetailsForViewVm destination, string destMember, AutoMapper.ResolutionContext context)
        {
            if (source.FlatNumber == 0)
            {
                return source.Street + " " + source.BuildingNumber;
            }
            else
            {
                return source.Street + " " + source.BuildingNumber + "/" + source.FlatNumber;
            }
        }
    }
}
