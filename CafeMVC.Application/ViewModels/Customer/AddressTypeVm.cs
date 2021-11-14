using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.ViewModels.Customer
{
    public class AddressTypeVm : IMapFrom<CafeMVC.Domain.Model.AddressType>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.AddressType, AddressTypeVm>();

        }
    }
}
