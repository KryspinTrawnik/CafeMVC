namespace CafeMVC.Domain.Model
{
    public class AddressType : BaseModel
    {
        public string Name { get; set; }

        public int AddersRef { get; set; }

        public Address Address { get; set; }
    }
}