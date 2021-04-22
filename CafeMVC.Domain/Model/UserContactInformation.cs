namespace CafeMVC.Domain.Model
{
    public class UserContactInformation :BaseModel
    {
        public string ContactDetailInformation { get; set; }

        public virtual int ContactDetailTypId { get; set; }

        public virtual ContactDetailInfotmationType ContactDetailInfotmationType {get; set;}

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
