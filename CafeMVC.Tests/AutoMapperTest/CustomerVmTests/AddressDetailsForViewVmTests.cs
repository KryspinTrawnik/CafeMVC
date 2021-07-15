using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Domain.Model;
using FluentAssertions;
using Xunit;

namespace CafeMVC.Tests.AutoMapperTest.CustomerVmTests
{
    public class AddressDetailsForViewVmTests
    {

        private AddressesForTests addressesForTests;
        public AddressDetailsForViewVmTests()
        {
            addressesForTests = new AddressesForTests();
        }

        public MapperConfiguration GetMapperConfiguration()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address, AddressDetailsForViewVm>()
                .ForMember(d => d.Type, opt => opt.MapFrom(d => d.AddressType.Name))
                .ForMember(d => d.Address, opt => opt.MapFrom(new ShortAddressResolver().Resolve));
            });

            return config;
        }

        [Fact]
        public void AddressDetailsForViewIsNotNull()
        {
            //Arrange
            var testedAdress = addressesForTests.GetAdrressForTest();
            var config = GetMapperConfiguration();
            var mapper = config.CreateMapper();

            //Act
            AddressDetailsForViewVm result = mapper.Map<AddressDetailsForViewVm>(testedAdress);
            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void AddressDetailsForViewIsCorrectType()
        {
            //Arrange
            var result = new AddressDetailsForViewVm();
            Address testedAdress = addressesForTests.GetAdrressForTest();
            MapperConfiguration config = GetMapperConfiguration();
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
            AddressDetailsForViewVm expected = addressesForTests.GetExpectedViewModelAdrressForTest();
            Address testedAdress = addressesForTests.GetAdrressForTest();
            var config = GetMapperConfiguration();
            config.AssertConfigurationIsValid();
            IMapper mapper = config.CreateMapper();

            //Act
            AddressDetailsForViewVm result = mapper.Map<AddressDetailsForViewVm>(testedAdress);

            //Assert
            result.Should().BeEquivalentTo(expected);
        }

    }
}
