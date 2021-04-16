namespace CafeMVC.Domain.Model
{
    public class DietInformation
    {
        public bool IsVegetarian { get; set; }

        public bool IsVegan { get; set; }

        public bool IsGlutenFree { get; set; }
         
        public int ProductRef { get; set; }

        public Product Product { get; set; }
    }
}