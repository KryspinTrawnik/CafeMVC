using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Orders;
using CafeMVC.Domain.Model;
using FluentValidation;
using FluentValidation.TestHelper;
using Xunit;

namespace CafeMVC.Tests.FluentValidationTests
{
    public class AddressForCreationValidatorTests
    {
        public AddressForCreationVm GetAddressForTests()
        {
            var vm = new AddressForCreationVm()
            {
                Id = 1,
                BuildingNumber = "2",
                FlatNumber = 1,
                Street = "Falcon",
                City = "Leicester",
                ZipCode = "LE1 2FG",
                Country = "United Kingdoms",
                AddressTypeId = 2
            };

            return vm;
        }

        [Theory]
        [InlineData("LE12 7EH")]
        [InlineData("LE5 7EH")]
        public void AddressForCreationValidatorShowErrorWIthWrongZipCode(string zipCode)
        {
            //Arrange
            AddressForCreationValidator validator = new();
            AddressForCreationVm addressForCreation = GetAddressForTests();
            addressForCreation.ZipCode = zipCode;
            //Act
            var result = validator.TestValidate(addressForCreation);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.ZipCode);
        }


        [Fact]
        public void AddressForCreationValidatorShowNoErrors()
        {
            //Arrange
            AddressForCreationValidator validator = new();
            AddressForCreationVm addressForCreation = GetAddressForTests();
            //Act
            var result = validator.TestValidate(addressForCreation);
            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData("LE12 7EH")]
        [InlineData("LE5 7EH")]
        public void AddressForCreationValidatorUnderOrderShowErrorWIthWrongZipCode(string zipCode)
        {
            //Arrange
            OrderForCreationValidator validator = new();
            OrderForCreationVm order = new()
            {
                Addresses = new()
            {
                GetAddressForTests()
            }
            };
            order.Addresses[0].ZipCode = zipCode;
            //Act
            var result = validator.TestValidate(order);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Addresses[0].ZipCode);
        }
    }
}
