using CafeMVC.Application.ViewModels.Orders;
using CafeMVC.Domain.Model;
using System;

namespace CafeMVC.Application.Interfaces.Mapping
{
    public class CreditCardForUserResolver : IValueResolver<PaymentCard, object, string>
    {
        public string Resolve(PaymentCard source, object destination, string destMember, AutoMapper.ResolutionContext context)
        {
            string value = string.Concat(source.CardNumber.AsSpan(0, 4), " ... ", source.CardNumber.AsSpan(source.CardNumber.Length - 4, 4));
            
            return value;       
        }

    }
}
