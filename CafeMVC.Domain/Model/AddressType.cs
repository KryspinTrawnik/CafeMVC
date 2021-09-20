using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class AddressType : BaseModel
    {
        public string Name { get; set; }

        public ICollection <Address> Addresses { get; set; }


    }
}