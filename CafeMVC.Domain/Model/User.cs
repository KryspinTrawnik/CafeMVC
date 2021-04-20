using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Domain.Model
{
    public class User  : BaseModel
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public virtual UserContactInformation UserContactInformation {get; set;}
    }
}
