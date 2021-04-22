namespace CafeMVC.Domain.Model
{
    public class ContactDetailInfotmationType :BaseModel
    {

        public string Name { get; set;  }

        public int UserContactInformationRef { get; set; }

        public UserContactInformation UserContactInformation { get; set; }
    }
}