using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

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
        {
            profile.CreateMap<AddressForCreationVm, CafeMVC.Domain.Model.Address>().ReverseMap();

        }
    }

    public class AddressForCreationValidator : AbstractValidator<AddressForCreationVm>
    {
        public AddressForCreationValidator()
        {
            string[] availableZipcodes = new string[] { "LE1 ", "LE2", "LE3", "LE4" };
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.AddressTypeId).NotNull();
            RuleFor(x => x.BuildingNumber).NotEmpty().MaximumLength(255);
            RuleFor(x => x.ZipCode).NotEmpty().Must(x => availableZipcodes.Any(prefix => x.StartsWith(prefix))).Length(7).When(x => x.AddressTypeId == 2);
            RuleFor(x => x.City).Equal("Leicester").When(x => x.AddressTypeId == 2);
            RuleFor(x => x.Country).MaximumLength(255).NotEmpty();
        }
    }
}

    