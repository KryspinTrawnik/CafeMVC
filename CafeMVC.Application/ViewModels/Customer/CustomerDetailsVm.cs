using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class CustomerDetailsVm : IMapFrom<CafeMVC.Domain.Model.Customer>
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public List<AddressForListVm> AddressForListVm { get; set; }

        public List<ContactDetailForViewVm> ContactDetails { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Customer, CustomerDetailsVm>()
                .ForMember(s => s.FullName, opt => opt.MapFrom(d => d.FirstName + " " + d.Surname))
               

        }

    }
}
