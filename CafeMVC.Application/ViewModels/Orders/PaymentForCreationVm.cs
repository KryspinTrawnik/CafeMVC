using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class PaymentForCreationVm : IMapFrom<CafeMVC.Domain.Model.Payment>
    {
        public int Id { get; set; }

        public PaymentCardForCreationVm PaymentCard { get; set; }

        public bool IsCompleted { get; set; }

        public int? PaymentCardId { get; set; }

        public List<PaymentTypeForCreation> AllPaymentTypes{ get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PaymentForCreationVm, CafeMVC.Domain.Model.Payment>().ReverseMap();

        }

    }
}