using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.Interfaces.Mapping
{
    public class CustomResolver : IValueResolver<Address, AddressForOrderSummaryVm, string>
    {
        public string Resolve(Address address, AddressForOrderSummaryVm addreassForSummary, string destMember, AutoMapper.ResolutionContext context)
        {
            if (address.FlatNumber == null)
            {
                return ($"{address.Street}  {address.BuildingNumber}\n" +
                    $"{address.City} {address.ZipCode}");
            }
            else
            {
                return ($"{address.Street} {address.BuildingNumber}/{address.FlatNumber}\n" +
                    $"{address.City} {address.ZipCode}");
            }
        }
    }
}
