using CafeMVC.Application.Services.Helpers;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CafeMVC.Tests.HelperTests
{
    public class SumUpOfListOfIntsTests
    {
        [Fact]
        public void SummaryListOfIntsZero()
        {
            //Arrange
            List<int> numbers = new() { 1, 2, 3, 4, 5 };
            //Act
            int result = Helper.SumUpListOfInts(numbers);
            //Assert
            result.Should().NotBe(0);
        }

        [Fact]
        public void SummaryListOfIntsResultIsCorrect()
        {
            //Arrange
            List<int> numbers = new() { 1, 2, 3, 4, 5 };
            int expected = 15;
            //Act
            int result = Helper.SumUpListOfInts(numbers);
            //Assert
            result.Should().Be(expected);
        }
    }
}
