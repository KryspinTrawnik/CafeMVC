using CafeMVC.Application.Interfaces.Mapping;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class PaymentCardForCreationVm : IMapFrom<CafeMVC.Domain.Model.PaymentCard>
    {
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public string CardType { get; set; }

        public int CardTypeId { get; set; }

        public string ExpirationDate { get; set; }

        public string CardHolderName { get; set; }

        public string SecureityCode { get; set; }

    }
}