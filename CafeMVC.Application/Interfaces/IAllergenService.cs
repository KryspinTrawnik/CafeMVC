using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Model;
using System.Collections.Generic;

namespace CafeMVC.Application.Interfaces
{
    public interface IAllergenService
    {
        void AddNewAllergen(AllergenForViewVm allergen);

        void DeleteAllergen(int allergenId);

        List<AllergenForViewVm> GetAllAllergens();

        List<AllergenForViewVm> GetAllProductAllergens(int productId);

        void UpdateProductAllergenTable(int productId, List<ProductAllergen> productAllergens);

        ListOfAllergensVm GetAllergensForEdition(int pageSize, int pageNo, string searchString);

        AllergenForViewVm GetAllergenVm(int allergenId);
        
        void ChangeAllergen(AllergenForViewVm editedAllergen);

    }
}
