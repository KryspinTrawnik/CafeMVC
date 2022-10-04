using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class ContactDetail : BaseModel
    {
        public string ContactDetailInformation { get; set; }

        public int ContactDetailTypeId { get; set; }

        public int? CustomerId { get; set; }

        public virtual ContactDetailType ContactDetailType { get; set; }

        public virtual ICollection<OrderContactDetail> OrderContactDetails { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
