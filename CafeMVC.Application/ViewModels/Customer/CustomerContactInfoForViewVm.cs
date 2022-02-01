using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class CustomerContactInfoForViewVm : IMapFrom<CafeMVC.Domain.Model.ContactDetail>
    {
        public int Id { get; set; }

        public string ContactDetailType { get; set; }

        public string ContactDetailInformation { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.ContactDetail, CustomerContactInfoForViewVm>()
                .ForMember(s => s.ContactDetailType, opt => opt.MapFrom(d => d.ContactDetailType.Name));

        }
    }
}
