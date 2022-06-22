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
            List<double> numbers = new() { 1, 2, 3, 4, 5 };
            //Act
            double result = Helper.SumUpListOfDoubles(numbers);
            //Assert
            result.Should().NotBe(0);
        }

        [Fact]
        public void SummaryListOfIntsResultIsCorrect()
        {

            //Arrange
            List<double> numbers = new() { 1, 2, 3, 4, 5 };
            double expected = 15;
            //Act
            double result = Helper.SumUpListOfDoubles(numbers);
            //Assert
            result.Should().Be(expected);
        }
    }
}
