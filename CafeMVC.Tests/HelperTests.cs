using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CafeMVC.Application.Services;
using FluentAssertions;

namespace CafeMVC.Tests
{
    public class HelperTests
    {
        [Fact]
        public void RemoveSpecialCharacters_ShouldNotBeEmpty()
        {
            //Arrange
            var testedString = "@#Hello World//";
            //Act
            var result = testedString.RemoveSpecialCharacters();
            //Assert
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void RemoveSpecialCharacters_ShouldBeStringType()
        {
            //Arrange
            var testedString = "@#He$l%l^o W*orld//";
            //Act
            var result = testedString.RemoveSpecialCharacters();
            //Assert
            result.Should().BeOfType<string>();
        }

        [Fact]
        public void RemoveSpecialCharacters_ShouldRemoveAllSpecialCharacters()
        {
            //Arrange
            var testedString = "@#He!$l%l^o W*o(r)l<d./";
            var expected = "Hello World";
            //Act
            var result = testedString.RemoveSpecialCharacters();
            //Assert
            result.Should().BeEquivalentTo(expected);
        }

    }
}
