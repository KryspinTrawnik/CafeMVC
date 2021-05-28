using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class AddressForOrderSummaryVm : IMapFrom<CafeMVC.Domain.Model.Address>
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Address, AddressForOrderSummaryVm>()
                .ForMember(s => s.Type, opt => opt.MapFrom(d => d.AddressType.Name));
          
            profile.CreateMap<CafeMVC.Domain.Model.Address, AddressForOrderSummaryVm>()
            .ForMember(s => s.Address, opt => opt.MapFrom(src => src.Street +" "+ src.BuildingNumber
            + ))
        }
    }
}
