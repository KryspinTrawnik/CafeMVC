using CafeMVC.Application.Services.Helpers;
using FluentAssertions;
using Xunit;

namespace CafeMVC.Tests.HelperTests
{
    public class GetNumberFromPostCodeTests
    {
        [Fact]
        public void StringToDecimalIsNotZero()
        {
            //Arrange
            string postCode = "LE1 7EH";
            Helper helper = new();
            //Act
            decimal result = helper.GetNumberFromPostCode(postCode);
            //Assert
            result.Should().NotBe(0);
        }

        [Fact]
        public void StringToDecimaGivesRightResult()
        {
            //Arrange
            string postCode = "LE1 7EH";
            int expected = 1;
            Helper helper = new();
            //Act
            decimal result = helper.GetNumberFromPostCode(postCode);
            //Assert
            result.Should().Be(expected);
        }
    }
}
