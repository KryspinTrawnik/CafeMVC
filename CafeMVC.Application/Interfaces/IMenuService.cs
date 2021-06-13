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
        ListOfMenusVm GetAllMenus();

        MenuForViewVm GetAllProducstOfMenu(int menuTypeId);

        MenuForViewVm GetProductsByDieteInfo(DietInfoForViewVm dieteInfo, int menuTypeId);

        void AddProductToMenu(int productI, int menuId);

        void DeleteProductFromMenu(int productId, int menuId);

        void AddNewMenu(MenuForCreationVm menuModel);

        void DeleteMenu(int menuId);

        void ChangeMenu(MenuForViewVm menuModel);

    }
}
