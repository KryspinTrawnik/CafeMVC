using CafeMVC.Domain.Model;
using System;

namespace CafeMVC.Application.Interfaces.Mapping
{
    public class LongAddressResolver : IValueResolver<Address, object, string>
    {
        private static string _longAddressFormat = $"{0} {1}{Environment.NewLine}{2}{Environment.NewLine}{3}";

        public string Resolve(Address source, object destination, string destMember, AutoMapper.ResolutionContext context)
            => source.FlatNumber == 0
                ? string.Format(_longAddressFormat, source.Street, source.BuildingNumber, source.ZipCode, source.City)
                : string.Format(_longAddressFormat, source.Street, $"{source.BuildingNumber}/{source.FlatNumber}", source.City);
    }
}
