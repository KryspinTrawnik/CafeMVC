using CafeMVC.Application.Services.Helpers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CafeMVC.Tests.HelperTests
{
   public class SumUpOfListOfDuoblesTest
    {
        [Fact]
        public void SummaryListOfIntsZero()
        {
            //Arrange
            List<decimal> numbers = new() { 1, 2, 3, 4, 5 };
            //Act
            decimal result = Helper.SumUpListOfDecimals(numbers);
            //Assert
            result.Should().NotBe(0);
        }

        [Fact]
        public void SummaryListOfIntsResultIsCorrect()
        {

            //Arrange
            List<decimal> numbers = new() { 1, 2, 3, 4, 5 };
            decimal expected = 15;
            //Act
            decimal result = Helper.SumUpListOfDecimals(numbers);
            //Assert
            result.Should().Be(expected);
        }
    }
}
