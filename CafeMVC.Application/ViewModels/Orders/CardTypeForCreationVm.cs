using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class CardTypeForCreationVm : IMapFrom<CafeMVC.Domain.Model.CardType>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.CardType, CardTypeForCreationVm>().ReverseMap();

        }
    }
}