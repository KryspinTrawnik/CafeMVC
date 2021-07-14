using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.Interfaces.Mapping
{
    public class LongAddressResolver : IValueResolver<Address, object, string>
    {
        public string Resolve(Address source, object destination, string destMember, AutoMapper.ResolutionContext context)
        {
            if (source.FlatNumber == 0)
            {
                destMember = source.Street + " " + source.BuildingNumber + "\n"
                    + source.ZipCode + " " + source.City;
            }
            else
            {
                destMember = source.Street + " " + source.BuildingNumber + "/" + source.FlatNumber + "\n"
                    + source.ZipCode + " " + source.City;

            }

            return destMember;
        }
    }
}
