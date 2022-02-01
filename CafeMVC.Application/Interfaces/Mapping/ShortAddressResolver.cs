using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Domain.Model;

namespace CafeMVC.Application.Interfaces.Mapping
{
    public class ShortAddressResolver : IValueResolver<Address, AddressDetailsForViewVm, string>
    {
        public string Resolve(Address source, AddressDetailsForViewVm destination, string destMember, AutoMapper.ResolutionContext context)
        => source.FlatNumber == 0
            ? $"{source.Street} {source.BuildingNumber}"
            : $"{source.Street} {source.BuildingNumber}/{source.FlatNumber}";

    }
}
