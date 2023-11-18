using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using CafeMVC.Application.ViewModels.Orders;
using CafeMVC.Domain.Model;
using FluentAssertions;
using Xunit;

namespace CafeMVC.Tests.AutoMapperTest
{
    public class CreditCardForUserResolverTests
    {
        public MapperConfiguration GetMapperConfiguration()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PaymentCard, CafeMVC.Application.ViewModels.Orders.CreditCardForUserListVm>()
                .ForMember(d => d.CreditCardNumber, opt =>
                {
                    opt.MapFrom(new CreditCardForUserResolver().Resolve);
                });
            });

            return config;
        }
        public PaymentCard GetPaymentCardForTests()
        {
            PaymentCard paymentCard = new PaymentCard()
            {
                Id = 1,
                CardNumber = "5574 8337 3253 4721",
                CardTypeId = 1,
                ExpirationDate = "12/25",
                CardHolderName = "Kryspin Trawnik",
                SecureityCode = "32",
            };

            return paymentCard;
        }
        [Fact]
        public void MappingCreditCardForUserListVmIsNotNull()
        {
            //Arrange
            var testedCard = GetPaymentCardForTests();
            var config = GetMapperConfiguration();
            var mapper = config.CreateMapper();

            //Act
            CreditCardForUserListVm result = mapper.Map<CreditCardForUserListVm>(testedCard);
            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void MappingCreditCardForUserListVmReturnCorrectValue()
        {
            //Arrange
            var testedCard = GetPaymentCardForTests();
            var config = GetMapperConfiguration();
            var mapper = config.CreateMapper();
            string expected = "5574 ... 4721";
            //Act
            CreditCardForUserListVm result = mapper.Map<CreditCardForUserListVm>(testedCard);
            //Assert
            result.CreditCardNumber.Should().BeEquivalentTo(expected);
        }
    }
}
