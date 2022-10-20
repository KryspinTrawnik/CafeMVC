using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;

namespace CafeMVC.Application.ViewModels.Menu
{
    public class MenuForListVm : IMapFrom<CafeMVC.Domain.Model.Menu>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsItPublic { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Menu, MenuForListVm>();

        }
    }
   

}
