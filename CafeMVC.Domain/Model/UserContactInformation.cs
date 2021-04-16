using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Domain.Model
{
    public class UserContactInformation
    {
        public int Id { get; set; }

        public string ContactDetailInformation { get; set; }

        public virtual int ContactDetailTypId { get; set; }

        public virtual ContactDetailInfotmationType ContactDetailInfotmationType {get; set;}

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
