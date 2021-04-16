namespace CafeMVC.Domain.Model
{
    public class ContactDetailInfotmationType
    {
        public int Id { get; set; }

        public string Type { get; set;  }

        public int UserContactInformationRef { get; set; }

        public UserContactInformation UserContactInformation { get; set; }
    }
}