using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class ContactDetailForViewVm : IMapFrom<CafeMVC.Domain.Model.CustomerContactInformation>
    {
        public int Id { get; set; }

        public string ContactDetailType { get; set; }

        public string ContactDetailInformation { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.CustomerContactInformation, ContactDetailForViewVm>()
                .IncludeMembers(s => s.ContactDetailInfotmationType)
                .ForMember(s => s.ContactDetailType, opt => opt.MapFrom(d => d.ContactDetailInfotmationType.Name));

        }
    }
}
