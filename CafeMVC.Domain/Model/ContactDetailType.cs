using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class ContactDetailType : BaseModel
    {

        public string Name { get; set; }

        public ICollection<ContactDetail> ContactDetails { get; set; }
    }
}