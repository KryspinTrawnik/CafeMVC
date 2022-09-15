using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;

namespace CafeMVC.Application.ViewModels.Orders
{
    public class StatusForCreationVm : IMapFrom<CafeMVC.Domain.Model.Status>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Status, StatusForCreationVm>().ReverseMap();

        }
    }
}