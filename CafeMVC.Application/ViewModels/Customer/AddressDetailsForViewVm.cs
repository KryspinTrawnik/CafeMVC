using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class AddressDetailsForViewVm :IMapFrom<CafeMVC.Domain.Model.Address>
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Address, AddressDetailsForViewVm>()
                .ForMember(s => s.Address, opt =>
                {
                opt.PreCondition(x => x.FlatNumber > 0);
                opt.MapFrom(d => d.Street + " " + d.BuildingNumber + "/" + d.FlatNumber);
                 });

            profile.CreateMap<CafeMVC.Domain.Model.Address, AddressDetailsForViewVm>()
              .ForMember(s => s.Address, opt =>
              {
                  opt.PreCondition(x => x.FlatNumber == 0);
                  opt.MapFrom(d => d.Street + " " + d.BuildingNumber);
              });


            profile.CreateMap<CafeMVC.Domain.Model.Address, AddressDetailsForViewVm>()
                .ForMember(s => s.Type, opt => opt.MapFrom(d => d.AddressType.Name));
        }         
    }
}
