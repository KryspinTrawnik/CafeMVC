namespace CafeMVC.Domain.Model
{
    public class ContactDetailInfotmationType :BaseModel
    {

        public string Name { get; set;  }

        public int CustomerContactInformationRef { get; set; }

        public CustomerContactInformation CustomerContactInformation { get; set; }
    }
}