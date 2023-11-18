using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class CreditCardForUserListVm : IMapFrom<CafeMVC.Domain.Model.PaymentCard>
    {
        public int Id { get; set; }

        public string CreditCardNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.PaymentCard, CreditCardForUserListVm>()
                .ForMember(d => d.CreditCardNumber, opt =>
                {
                    opt.MapFrom(new CreditCardForUserResolver().Resolve);
                }); 

        }
    }
}