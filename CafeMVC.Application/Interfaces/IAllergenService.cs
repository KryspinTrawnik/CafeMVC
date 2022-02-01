using CafeMVC.Application.ViewModels.Products;

namespace CafeMVC.Application.Interfaces
{
    public interface IAllergenService
    {
        void AddAllergenToProduct(int productId, int allergenId);
       
        void AddNewAllergen(AllergenForViewVm allergen);

        void deleteAllergen(int allergenId);

        void DeleteAllergenFromProduct(int productId, int allergenId);

    }
}
