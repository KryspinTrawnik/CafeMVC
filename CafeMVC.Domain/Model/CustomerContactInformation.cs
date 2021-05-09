namespace CafeMVC.Domain.Model
{
    public class CustomerContactInformation :BaseModel
    {
        public string ContactDetailInformation { get; set; }

        public virtual int ContactDetailTypId { get; set; }

        public virtual ContactDetailInfotmationType ContactDetailInfotmationType {get; set;}

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
