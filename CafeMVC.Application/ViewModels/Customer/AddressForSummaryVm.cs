using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class AddressForSummaryVm : IMapFrom<CafeMVC.Domain.Model.Address>
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Address, AddressForSummaryVm>()
                .ForMember(s => s.Type, opt => opt.MapFrom(d => d.AddressType.Name))
                .ForMember(s => s.Address, opt =>
                {
                    opt.MapFrom(new LongAddressResolver().Resolve);
                });
        }
    }
}
