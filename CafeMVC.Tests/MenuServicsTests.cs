using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using CafeMVC.Application.Services;
using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using CafeMVC.Infrastructure.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CafeMVC.Tests.MenuServiceTest
{
    public class MenuServicsTests
    {
        [Fact]
        public void AddProductToMenuShouldWork()
        {
            //Arrange
            var otherModelsForTesting = new OtherModelsForTesting();
            var productForTesting = new ProductsForTesting();
            Menu menuForTest = otherModelsForTesting.GetBajgleMenu();
            Product product = productForTesting.GetProductsForBajgleMenu().FirstOrDefault(x => x.Id == 1);

            var productRepository = new Mock<IProductRepository>();
            var menuRepository = new Mock<IMenuRepository>();
            menuRepository.Setup(m => m.GetMenuById(1)).Returns(menuForTest);
            productRepository.Setup(p => p.GetProductById(1)).Returns(product);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();
            var menuService = new MenuService(menuRepository.Object, mapper, productRepository.Object);
            //Act
            menuService.AddProductToMenu(1, 1);
            //Assert


        }
    }
}
