using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using CafeMVC.Domain.Model;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class AddressDetailsForViewVm :IMapFrom<Address>
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, AddressDetailsForViewVm>()
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.AddressType.Name))
                .ForMember(d => d.Address, opt => opt.MapFrom(new ShortAddressResolver().Resolve));

        }


    }
}
