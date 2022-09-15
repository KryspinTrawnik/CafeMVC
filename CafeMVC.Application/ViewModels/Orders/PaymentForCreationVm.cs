using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class PaymentForCreationVm : IMapFrom<CafeMVC.Domain.Model.Payment>
    {
        public int Id { get; set; }

        public virtual PaymentCardForCreationVm PaymentCard { get; set; }

        public bool IsCompleted { get; set; }

        public int? PaymentCardId { get; set; }

        public List<PaymentTypeForCreationVm> AllPaymentTypes { get; set; }

        public int PaymentTypeId { get; set; }

        public PaymentTypeForCreationVm PaymentType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PaymentForCreationVm, CafeMVC.Domain.Model.Payment>().ReverseMap();

        }

    }
}