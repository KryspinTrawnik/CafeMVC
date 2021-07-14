﻿using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Domain.Model;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CafeMVC.Tests.AutoMapperTest.CustomerVmTests
{
    public class AddressDetailsForViewVmTests
    {
        private Address GetAdrressForTest()
        {
            var address = new Address()
            {
                Id = 1,
                BuildingNumber = "3",
                FlatNumber = 5,
                Street = "Aleja Wojska Polskiego",
                City = "Kalisz",
                ZipCode = "62-800",
                Country = "Polska",
                TypeId = 1,
                AddressType = new AddressType()
                {
                    Id = 1,
                    Name = "Adres rozliczeniowy"
                }
            };
            return address;
        }
        private AddressDetailsForViewVm GetExpectedViewModelAdrressForTest()
        {
            var expectedAddress = new AddressDetailsForViewVm()
            {
                Id = 1,
                Address = "Aleja Wojska Polskiego 3/5",
                City = "Kalisz",
                ZipCode = "62-800",
                Country = "Polska",
                Type = "Adres rozliczeniowy"

            };
            return expectedAddress;
        }
        [Fact]
        public void AddressDetailsForViewIsNotNull()
        {
            //Arrange
            var result = new AddressDetailsForViewVm();
            var testedAdress = GetAdrressForTest();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address, AddressDetailsForViewVm>()
                .ForMember(d => d.Type, opt => opt.MapFrom(d => d.AddressType.Name))
                .ForMember(d => d.Address, opt => opt.MapFrom(new ShortAddressResolver().Resolve));
            });
            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();

            //Act
            result = mapper.Map<AddressDetailsForViewVm>(testedAdress);
            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void AddressDetailsForViewIsCorrectType()
        {
            //Arrange
            var result = new AddressDetailsForViewVm();
            var testedAdress = GetAdrressForTest();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address, AddressDetailsForViewVm>()
                .ForMember(d => d.Type, opt => opt.MapFrom(d => d.AddressType.Name))
                .ForMember(d => d.Address, opt => opt.MapFrom(new ShortAddressResolver().Resolve));
            });
            var mapper = config.CreateMapper();

            //Act
            result = mapper.Map<AddressDetailsForViewVm>(testedAdress);
            //Assert
            result.Should().BeOfType<AddressDetailsForViewVm>();
        }
        [Fact]
        public void AddressDetailsForViewReturnsRightModel()
        {
            //Arrange
            AddressDetailsForViewVm expected = GetExpectedViewModelAdrressForTest();
            AddressDetailsForViewVm result = new AddressDetailsForViewVm();
            Address testedAdress = GetAdrressForTest();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address, AddressDetailsForViewVm>()
                .ForMember(d => d.Type, opt => opt.MapFrom(d => d.AddressType.Name))
                .ForMember(d => d.Address, opt => opt.MapFrom(new ShortAddressResolver().Resolve));
            });
            config.AssertConfigurationIsValid();

            IMapper mapper = config.CreateMapper();

            //Act
            result = mapper.Map<AddressDetailsForViewVm>(testedAdress);

            //Assert

            result.Should().BeEquivalentTo(expected);
        }

    }
}
