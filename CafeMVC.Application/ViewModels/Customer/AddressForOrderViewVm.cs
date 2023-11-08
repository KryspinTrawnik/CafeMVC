using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class AddressForOrderViewVm : IMapFrom<CafeMVC.Domain.Model.Address>
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public int CustomerId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Address, AddressForOrderViewVm>()
                .ForMember(s => s.Address, opt =>
                {
                    opt.MapFrom(new LongAddressResolver().Resolve);
                });
        }
    }
}
