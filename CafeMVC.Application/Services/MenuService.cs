using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Menu;
using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace CafeMVC.Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public MenuService(IMenuRepository menuRepository, IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public void AddNewMenu(MenuForCreationVm menuModel)
        {
            Menu menu = _mapper.Map<Menu>(menuModel);
            _menuRepository.AddItem(menu);
        }

        public void AddProductToMenu(int productId, int menuId)
        {
            Menu menu = _menuRepository.GetItemById(menuId);
            menu.Products.Add(_productRepository.GetItemById(productId));
            _menuRepository.UpdateItem(menu);
        }

        public void ChangeMenu(MenuForViewVm menuModel)
        {
            Menu menu = _mapper.Map<Menu>(menuModel);
            _menuRepository.UpdateItem(menu);
        }

        public void DeleteMenu(int menuId)
        {
            _menuRepository.DeleteItem(menuId);
        }

        public void DeleteProductFromMenu(int productId, int menuId)
        {
            Product prodtuctToRemove = _productRepository.GetItemById(productId);
            _menuRepository.GetItemById(menuId).Products.Remove(prodtuctToRemove);
        }

        public ListOfMenusVm GetAllMenus(int pageSize, int pageNo, string searchString)
        {
            List<MenuForListVm> allMenus = _menuRepository.GetAllType().ProjectTo<MenuForListVm>(_mapper.ConfigurationProvider).ToList();
            var menusToDisplay = allMenus.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            ListOfMenusVm listOfMenus = new()
            {
                ListOfAllMenus = menusToDisplay,
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Count = allMenus.Count
            };
            return listOfMenus;
        }

        public MenuForViewVm GetAllProducstOfMenu(int menuId)
        {
            Menu menu = _menuRepository.GetItemById(menuId);
            MenuForViewVm menuVm = _mapper.Map<MenuForViewVm>(menu);
            return menuVm;
        }

        public MenuForViewVm GetProductsByDieteInfo(DietInfoForViewVm dieteInfoVm, int menuTypeId)
        {
            DietInformation dietInfo = _mapper.Map<DietInformation>(dieteInfoVm);
            Menu menu = _menuRepository.GetMenuByDietInformation(menuTypeId, dietInfo);
            MenuForViewVm menuVm = _mapper.Map<MenuForViewVm>(menu);
            return menuVm;
        }
    }
}
