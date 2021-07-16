using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Domain.Model;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Tests.AutoMapperTest.CustomerVmTests
{
    public class AddressForOrderSummaryVmTest
    {
        private AddressesForTests addressesForTests;

        public AddressForOrderSummaryVmTest()
        {
            addressesForTests = new AddressesForTests();
        }


        public MapperConfiguration GetMapperConfiguration()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address, Application.ViewModels.Customer.AddressForOrderSummaryVm>()
                .ForMember(d => d.Type, opt => opt.MapFrom(d => d.AddressType.Name))
                .ForMember(d => d.Address, opt => opt.MapFrom(new LongAddressResolver().Resolve));
            });

            return config;
        }
        public void MappingAddressForOrderSummaryVmShouldNotBeNull()
        {
            //Arrange
            var testedAdress = addressesForTests.GetAdrressForTest();
            var config = GetMapperConfiguration();
            var mapper = config.CreateMapper();

            //Act
            AddressForOrderSummaryVm result = mapper.Map<AddressForOrderSummaryVm>(testedAdress);
            //Assert
            result.Should().NotBeNull();
        }
        public void MappingAddressForOrderSummaryVmShouldBeRightType()
        {
            //Arrange
            var testedAdress = addressesForTests.GetAdrressForTest();
            var config = GetMapperConfiguration();
            var mapper = config.CreateMapper();

            //Act
            AddressForOrderSummaryVm result = mapper.Map<AddressForOrderSummaryVm>(testedAdress);
            //Assert
            result.Should().BeOfType<AddressForOrderSummaryVm>();
        }
        public void MappingAddressForOrderSummaryVmShouldReturnRightModel()
        {
            //Arrange
            var testedAdress = addressesForTests.GetAdrressForTest();
            var config = GetMapperConfiguration();
            var mapper = config.CreateMapper();
            AddressForOrderSummaryVm expected = addressesForTests.GetExpectedViewModelOfLongAdrressForTest();
            //Act
            AddressForOrderSummaryVm result = mapper.Map<AddressForOrderSummaryVm>(testedAdress);
            //Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
