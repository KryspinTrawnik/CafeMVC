using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class ContactDetailTypeForCreationVm : IMapFrom<CafeMVC.Domain.Model.ContactDetailType>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContactDetailTypeForCreationVm, CafeMVC.Domain.Model.ContactDetailType > ().ReverseMap();

        }
    }
}