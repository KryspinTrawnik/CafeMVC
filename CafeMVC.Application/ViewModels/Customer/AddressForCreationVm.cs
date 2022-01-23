using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class AddressForCreationVm : IMapFrom<CafeMVC.Domain.Model.Address>
    {
        public int Id { get; set; }

        public string BuildingNumber { get; set; }

        public int FlatNumber { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public int CustomerId { get; set; }

        public int AddressTypeId { get; set; }

        public List<AddressTypeVm> AllAddressTypes { get; set; }

        public string Btn { get; set; }

        public void Mapping(Profile profile)
            => profile.CreateMap<AddressForCreationVm, CafeMVC.Domain.Model.Address>().ReverseMap();

    }
}