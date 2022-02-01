using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class CustomerForCreationVm : IMapFrom<CafeMVC.Domain.Model.Customer>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public List<AddressForCreationVm> Addresses { get; set; }

        public List<ContactInfoForCreationVm> ContactDetails { get; set; }

        public string Btn { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CustomerForCreationVm, CafeMVC.Domain.Model.Customer> ().ReverseMap();

        }
    }
}
