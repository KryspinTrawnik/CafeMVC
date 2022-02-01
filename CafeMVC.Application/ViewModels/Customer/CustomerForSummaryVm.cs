using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class CustomerForSummaryVm : IMapFrom<CafeMVC.Domain.Model.Customer>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public List<AddressForSummaryVm> Addresses { get; set; }

        public List<CustomerContactInfoForViewVm> ContactDetails { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Customer, CustomerForSummaryVm>();

        }
    }
}
