namespace CafeMVC.Domain.Model
{
    public class ContactDetail :BaseModel
    {
        public string ContactDetailInformation { get; set; }

        public virtual int ContactDetailTypId { get; set; }

        public virtual ContactDetailType ContactDetailType {get; set;}

    }
}
