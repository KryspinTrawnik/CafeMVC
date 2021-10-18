using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class AddressType : BaseModel
    {
        public string Name { get; set; }

        public virtual ICollection <Address> Addresses { get; set; }


    }
}