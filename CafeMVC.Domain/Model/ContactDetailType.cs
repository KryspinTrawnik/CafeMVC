namespace CafeMVC.Domain.Model
{
    public class ContactDetailType :BaseModel
    {

        public string Name { get; set;  }

        public int CustomerContactInformationRef { get; set; }

        public ContactDetail CustomerContactInformation { get; set; }
    }
}