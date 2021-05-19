namespace CafeMVC.Application.ViewModels.Customer
{
    public class AddressForCreationVm
    {
        public int Id { get; set; }

        public string BuildingNumber { get; set; }

        public int FlatNumber { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public string Type { get; set; }

    }
}