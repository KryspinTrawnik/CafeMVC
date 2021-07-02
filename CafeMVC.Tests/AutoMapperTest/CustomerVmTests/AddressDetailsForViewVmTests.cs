using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Domain.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CafeMVC.Tests.AutoMapperTest.CustomerVmTests
{
    public class AddressDetailsForViewVmTests
    {
        
        [Fact]
        public void AddressDetailsForViewIsNotNull()
        {
            //Arrange
            var mapper = new Mock<IMapper>();
            mapper.Setup(x => x.ConfigurationProvider)
            .Returns(
            () => new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new MappingProfile());

            }));
            var 
            //Act
            //Assert
        }
    }
}
