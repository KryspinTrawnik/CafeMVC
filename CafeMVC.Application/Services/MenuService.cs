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
            => _menuRepository.AddNewMenu(_mapper.Map<Menu>(menuModel));

        public void AddProductToMenu(int productId, int menuId)
        {
            Menu menu = _menuRepository.GetMenuById(menuId);
            if (menu is null)
            {
                // jakas logika, nie sprawdzasz, czy takie menu istnieje
            }

            // nie sprawdzasz czy produkt istnieje w bazie i probujesz dodac nulla
            menu.Products.Add(_productRepository.GetProductById(productId));
            _menuRepository.UpdateMenu(menu);
        }

        public void ChangeMenu(MenuForViewVm menuModel)
            => _menuRepository.UpdateMenu(_mapper.Map<Menu>(menuModel));

        public void DeleteMenu(int menuId) =>  _menuRepository.DeleteMenu(menuId);

        public void DeleteProductFromMenu(int productId, int menuId)
        {
            Product productToRemove = _productRepository.GetProductById(productId);
            if (productToRemove is null)
            {
                // logika
            }

            _menuRepository.GetMenuById(menuId).Products.Remove(productToRemove);
        }

        public ListOfMenusVm GetAllMenus(int pageSize, int pageNo, string searchString)
        {
            List<MenuForListVm> allMenus = _menuRepository
                .GetAllActiveMenus().ProjectTo<MenuForListVm>(_mapper.ConfigurationProvider).Skip(pageSize * (pageNo - 1)).Take(pageSize)
                .ToList();

            return new()
            {
                ListOfAllMenus = allMenus,
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Count = allMenus.Count
            };
        }

        public MenuForViewVm GetAllProducstOfMenu(int menuId) => _mapper.Map<MenuForViewVm>(_menuRepository.GetMenuById(menuId));

        public MenuForViewVm GetProductsByDieteInfo(DietInfoForViewVm dieteInfoVm, int menuTypeId)
        {
            DietInfoTag dietInfo = _mapper.Map<DietInfoTag>(dieteInfoVm);
            Menu menu = _menuRepository.GetMenuByDietInformation(menuTypeId, dietInfo);

            return _mapper.Map<MenuForViewVm>(menu);
        }
    }
}
