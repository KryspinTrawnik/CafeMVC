using CafeMVC.Application.Services.Helpers;
using FluentAssertions;
using Xunit;

namespace CafeMVC.Tests.HelperTestsKE
{
    public class CountDeliveryChargeTests
    {

        [Fact]
        public void CountDeliveryChargesIsNotZero()
        {
            //Arrange
            string postCode = "LE1 7EH";
            Helper helper = new();
            //Act
            decimal result = helper.CountDeliveryCharge(postCode);
            //Assert
            result.Should().NotBe(0);

        }

        [Fact]
        public void CountDeliveryChargesGiveRightResult()
        {
            //Arrange
            string postCode = "LE1 7EH";
            decimal expected = 3;
            Helper helper = new();
            //Act
            decimal result = helper.CountDeliveryCharge(postCode);
            //Assert
            result.Should().Be(expected);
        }
    }
}
