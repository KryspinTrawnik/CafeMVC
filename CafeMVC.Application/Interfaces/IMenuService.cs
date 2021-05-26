using CafeMVC.Application.ViewModels.Menu;
using CafeMVC.Application.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.Interfaces
{
    public interface IMenuService
    {
        ListOfMenusVm GetAllMenuType();

        MenuForViewVm GetAllProducstOfMenu(int menuTypeId);

        MenuForViewVm GetProductsByDieteInfo(DietInfoForViewVm dieteInfo, int menuTypeId);

        void AddProductToMenu(ProductForListVm product, int menuId);

        void DeleteProductFromMenu(ProductForListVm product, int menuId);

        void AddNewMenu(MenuForCreationVm menuModel);

        void DeleteMenu(int menuId);

        void ChangeMenu(MenuForViewVm menuModel);

    }
}
