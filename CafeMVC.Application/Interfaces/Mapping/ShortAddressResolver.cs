using AutoMapper;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Domain.Model;

namespace CafeMVC.Application.Interfaces.Mapping
{
    public class ShortAddressResolver : IValueResolver<Address, AddressDetailsForViewVm, string>
    {
        public string Resolve(Address source, AddressDetailsForViewVm destination, string destMember, ResolutionContext context)
        {
            // ten else jest nie potrzebny, ogolnie wyrzuć te ify i zrob z tego one liner jak ja zrobilem w jednej z klas
            if (source.FlatNumber == 0)
            {
                return source.Street + " " + source.BuildingNumber;
            }

            return source.Street + " " + source.BuildingNumber + "/" + source.FlatNumber;
        }
    }
}
