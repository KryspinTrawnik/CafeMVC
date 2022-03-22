using CafeMVC.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CafeMVC.Tests
{
    public class StringToDoubleTests
    {
        [Fact]
        public void StringToDoubleIsNotZero()
        {
            //Arrange
            string number = "9.42";
            //Act
            double result =  Helper.StringToDouble(number);
            //Assert
            result.Should().NotBe(0);
        }
        [Fact]
        public void StringToDoubleReturnCorrect()
        {
            //Arrange
            string number = "9.42";
            //Act
            double result = Helper.StringToDouble(number);
            //Assert
            result.Should().Be(9.42);
        }

    }
}
