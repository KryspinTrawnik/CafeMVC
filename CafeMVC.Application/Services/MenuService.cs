using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Menu;
using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var menu = _mapper.Map<Menu>(menuModel);
            _menuRepository.AddItem(menu);
        }

        public void AddProductToMenu(int productId, int menuId)
        {
            var menu = _menuRepository.GetItemById(menuId);
            menu.Products.Add(_productRepository.GetItemById(productId));
            _menuRepository.UpdateItem(menu);
        }

        public void ChangeMenu(MenuForViewVm menuModel)
        {
            var menu = _mapper.Map<Menu>(menuModel);
            _menuRepository.UpdateItem(menu);
        }

        public void DeleteMenu(int menuId)
        {
            _menuRepository.DeleteItem(menuId);
        }

        public void DeleteProductFromMenu(int productId, int menuId)
        {
            var prodtuctToRemove = _productRepository.GetItemById(productId);
            _menuRepository.GetItemById(menuId).Products.Remove(prodtuctToRemove);
        }

        public ListOfMenusVm GetAllMenus()
        {
            var AllMenus = _menuRepository.GetAllType().ProjectTo<MenuForListVm>(_mapper.ConfigurationProvider).ToList();
            var listOfMenus = new ListOfMenusVm()
            {
                ListOfAllMenus = AllMenus,
                Count = AllMenus.Count()
            };
            return listOfMenus;
        }

        public MenuForViewVm GetAllProducstOfMenu(int menuId)
        {
            var menu = _menuRepository.GetItemById(menuId);
            var menuVm = _mapper.Map<MenuForViewVm>(menu);
            return menuVm;
        }

        public MenuForViewVm GetProductsByDieteInfo(DietInfoForViewVm dieteInfoVm, int menuTypeId)
        {
            var dietInfo = _mapper.Map<DietInformation>(dieteInfoVm);
            var menu = _menuRepository.GetMenuByDietInformation(menuTypeId, dietInfo);
            var menuVm = _mapper.Map<MenuForViewVm>(menu);
            return menuVm;
        }
    }
}
