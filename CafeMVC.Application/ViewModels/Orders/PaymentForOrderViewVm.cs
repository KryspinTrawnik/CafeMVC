using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class PaymentForOrderViewVm : IMapFrom<CafeMVC.Domain.Model.Payment>
    {
        public string PaymentType { get; set; }

        public bool IsCompleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Payment, PaymentForOrderViewVm>()
                .ForPath(d => d.PaymentType, opt => opt.MapFrom(s => s.PaymentType.Name));
        }
    }
}
