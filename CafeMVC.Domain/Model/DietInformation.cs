namespace CafeMVC.Domain.Model
{
    public class DietInformation : BaseModel
    {
        public bool IsVegetarian { get; set; }

        public bool IsVegan { get; set; }

        public bool IsGlutenFree { get; set; }

        public byte VegetarianImage { get; set; }

        public byte VeganImage { get; set; }

        public byte GlutenFreeImage { get; set; }

        public int ProductRef { get; set; }

        public Product Product { get; set; }
    }
}