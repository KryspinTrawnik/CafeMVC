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
        ListOfMenusForVm GetAllMenuType();

        MenuForVm GetAllProductOfMenu(int menuTypeId);

        MenuForVm GetProductByDieteInfo(DietInfoForVm dieteInfo, int menuTypeId);

        void AddProductToMenu(ProductForListVm product, int menuId);

        void DeleteProductFromMenu(ProductForListVm product, int menuId);

        void AddNewMenu(MenuCreationVm menuModel);

        void DeleteMenu(int menuId);

        void ChangeMenu(MenuForVm menuModel);

    }
}
