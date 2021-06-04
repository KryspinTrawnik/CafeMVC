using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Customer
{
   public class AddressForOrderViewVm : IMapFrom<CafeMVC.Domain.Model.Address>
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Address, AddressDetailsForViewVm>()
                .ForMember(s => s.Address, opt =>
                {
                    opt.PreCondition(x => x.FlatNumber == 0 && x.AddressType.Name == "Delivery Address");
                    opt.MapFrom(d => d.Street + " " + d.BuildingNumber + "\n"
                    + d.ZipCode + " " + d.City);
                })
                .ForMember(s => s.Address, opt =>
                {
                    opt.PreCondition(x => x.FlatNumber != 0 && x.AddressType.Name == "Delivery Address");
                    opt.MapFrom(d => d.Street + " " + d.BuildingNumber + "/" + d.FlatNumber
                    + "\n" + d.ZipCode + " " + d.City);
                });
        }
    }
}
