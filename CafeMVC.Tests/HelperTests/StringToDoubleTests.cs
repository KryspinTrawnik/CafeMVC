using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using CafeMVC.Application.Services.Helpers;

namespace CafeMVC.Tests.HelperTests
{
    public class StringToDecimalTests
    {
        [Fact]
        public void StringToDecimalIsNotZero()
        {
            //Arrange
            string number = "9.42";
            //Act
            decimal result = Helper.StringToDecimal(number);
            //Assert
            result.Should().NotBe(0);
        }
        [Fact]
        public void StringToDecimalReturnCorrect()
        {
            //Arrange
            string number = "9.42";
            //Act
            decimal result = Helper.StringToDecimal(number);
            //Assert
            result.Should().Be((decimal)9.42);
        }

        [Fact]
        public void StringWithCommaToDecimalReturnCorrect()
        {
            //Arrange
            string number = "9,42";
            //Act
            decimal result = Helper.StringToDecimal(number);
            //Assert
            result.Should().Be((decimal)9.42);
        }

    }
}
