using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class ContactInfoForCreationVm : IMapFrom<CafeMVC.Domain.Model.CustomerContactInformation>
    {
        public int Id { get; set; }

        public string ContactDetailInformation { get; set; }

        public ContactDetailTypeForCreationVm ContactDetailType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.CustomerContactInformation, ContactInfoForCreationVm>().ReverseMap();

        }
    }
}
