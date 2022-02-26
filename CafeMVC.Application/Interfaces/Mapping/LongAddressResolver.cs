using CafeMVC.Domain.Model;
using System;

namespace CafeMVC.Application.Interfaces.Mapping
{
    public class LongAddressResolver : IValueResolver<Address, object, string>
    {
        public string Resolve(Address source, object destination, string destMember, AutoMapper.ResolutionContext context)
        => source.FlatNumber == 0
            ? $"{source.Street} {source.BuildingNumber}{Environment.NewLine}{source.ZipCode}{Environment.NewLine}{source.City}"
            : $"{source.Street} {source.BuildingNumber}/{source.FlatNumber}\n{source.ZipCode}\n{source.City}";
            
    }
}
