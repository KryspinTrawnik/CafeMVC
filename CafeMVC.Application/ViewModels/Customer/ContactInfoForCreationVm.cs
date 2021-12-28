using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class ContactInfoForCreationVm : IMapFrom<CafeMVC.Domain.Model.ContactDetail>
    {
        public int Id { get; set; }

        public string ContactDetailInformation{ get; set; }

        public int ContactDetailTypeId { get; set; }

        public string ContactDetailType { get; set; }

        public List<ContactDetailTypeForViewVm> AllContactDetailsTypes { get; set; }

        public int CustomerId { get; set; }
        public string Btn { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContactInfoForCreationVm, CafeMVC.Domain.Model.ContactDetail>().ReverseMap()
                .ForMember(s => s.ContactDetailType, opt => opt.MapFrom(d =>d.ContactDetailType.Name));

        }
    }
}
