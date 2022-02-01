using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using CafeMVC.Application.ViewModels.Orders;
using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class CustomerDetailViewsVm : IMapFrom<CafeMVC.Domain.Model.Customer>
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public List<AddressForListVm> Addresses{ get; set; }

        public List<CustomerContactInfoForViewVm> ContactDetails { get; set; }

        public List<OrderForUserListVm> Orders{ get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Customer, CustomerDetailViewsVm>()
                .ForMember(s => s.FullName, opt => opt.MapFrom(d => d.FirstName + " " + d.Surname));
               
        }

    }
}
