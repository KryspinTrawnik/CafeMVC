using CafeMVC.Application.ViewModels.Menu;
using CafeMVC.Application.ViewModels.Products;

namespace CafeMVC.Application.Interfaces
{
    public interface IMenuService
    {
        ListOfMenusVm GetMenusToDisplay(int pageSize, int pageNo, string searchString);

        MenuForViewVm GetAllProducstOfMenu(int menuTypeId);

        MenuForViewVm GetProductsByDieteInfo(DietInfoForViewVm dieteInfo, int menuTypeId);

        void AddProductToMenu(int productI, int menuId);

        void DeleteProductFromMenu(int productId, int menuId);

        void AddNewMenu(MenuForCreationVm menuModel);

        void DeleteMenu(int menuId);

        void ChangeMenu(MenuForCreationVm menuModel);

        MenuForCreationVm GetMenuForCreation();

        MenuForViewVm GetMenuForView(int manuId);

        MenuForCreationVm GetMenuForEdition(int menuId);
    }
}
