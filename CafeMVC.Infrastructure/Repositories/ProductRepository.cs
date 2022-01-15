using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CafeMVC.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context) 
        {
            _context = context;
        }
        public Product GetProductById(int productId)
        {
            var product = _context.Products.AsNoTracking()
                .Include(x => x.ProductIngredients)
                .Include(x => x.Allergens)
                .Include(x => x.DietInformation)
                .FirstOrDefault(x => x.Id == productId);
            return product;
        }

        public void UpdateProduct(Product product)
        {
            _context.Attach(product);
            _context.Entry(product).Property("Name");
            _context.Entry(product).Property("Price");
            _context.Entry(product).Property("Description");
            _context.Entry(product).Property("ImagePath");
            _context.Entry(product).Collection("Ingredients");
            _context.Entry(product).Collection("Allergens");
            _context.Entry(product).Collection("DietInformation");
            _context.SaveChanges();
        }
        public void AddAllergenToProduct(int allergenId, int productId)
        {
            var product = GetProductById(productId);
            product.ProductAllergens.Add(GetAllergenById(allergenId));
            UpdateProduct(product);
        }

        public void AddIngredientToProduct(int ingredientId, int productId)
        {
            var product = GetProductById(productId);
            product.ProductIngredients.Add(GetIngredientById(ingredientId));
            UpdateProduct(product);
        }

        public IQueryable<Allergen> GetAllAllergensFromProduct(int productId)
        {

            return _context.Products.AsNoTracking().Include(x => x.ProductAllergens)
                .FirstOrDefault(x => x.Id == productId).ProductAllergens.AsQueryable();
        }

        public IQueryable<Ingredient> GetAllProductIngredients(int productId)
        {
            return _context.Products.AsNoTracking().Include(x => x.ProductIngredients)
                .FirstOrDefault(x => x.Id == productId).ProductIngredients.AsQueryable();

        }

        public void DeleteImageFromProduct(int productId)
        {
            Product product = GetProductById(productId);
            product.ImagePath = null;
            UpdateProduct(product);
        }

        public void AddNewImageToProduct(string imageName, int productId)
        {
            Product product = GetProductById(productId);
            product.ImagePath = imageName;
            UpdateProduct(product);
        }

        public void RemoveIngredientFromProduct(int ingredientId, int productId)
        {
            Product product = _context.Products.AsNoTracking().Include(x => x.ProductIngredients)
                .FirstOrDefault(x =>x.Id == productId);
            product.ProductIngredients.Remove(GetIngredientById(ingredientId));
            UpdateProduct(product);
        }


        public void RemoveAllergenFromProduct(int allergenId, int productId)
        {
            Product product = _context.Products.AsNoTracking().Include(x => x.ProductAllergens)
                .FirstOrDefault(x => x.Id == productId);
            product.ProductAllergens.Remove(GetAllergenById(allergenId));
            UpdateProduct(product);
        }

        public Ingredient GetIngredientById(int ingredientId) => _context.Ingredients.Find(ingredientId);

        public IQueryable<Ingredient> GetAllIngredients()
        {
            return _context.Ingredients;
        }

        public void AddNewIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
        }

        public Allergen GetAllergenById(int id)
        {
            return _context.Allergens.Find(id);
        }

        public IQueryable<Allergen> GetAllAllergens()
        {
            return _context.Allergens.AsNoTracking();
        }

        public void DeleteIngredient(int ingredientId)
        {
            _context.Ingredients.Remove(GetIngredientById(ingredientId));
            _context.SaveChanges();
        }

        public void AddNewAllergen(Allergen allergen)
        {
            _context.Allergens.Add(allergen);
            _context.SaveChanges();
        }

        public void AddDietInfoToProduct(int dietInfoId, int productId)
        {
            var product = _context.Products.AsNoTracking().Include(x => x.DietInfoTags)
                .FirstOrDefault(x => x.Id == productId);
            product.DietInfoTags.Add(_context.DietInformations.Find(dietInfoId));
            _context.SaveChanges();

        }

        public IQueryable<DietInfoTag> GetAllDietInfo()
        {
            return _context.DietInformations.AsNoTracking();
        }

        public IQueryable<DietInfoTag> GetAllProductDietInfo(int productId)
        {
            return _context.Products.AsNoTracking().Include(x => x.DietInfoTags)
                .FirstOrDefault(x => x.Id == productId).DietInfoTags.AsQueryable();

        }

        public void RemoveDietInfoFromProduct(int dietInfoId, int productId)
        {
            var product = _context.Products.AsNoTracking().Include(x => x.DietInfoTags)
                .FirstOrDefault(x => x.Id == productId);
            product.DietInfoTags.Add(_context.DietInformations.Find(dietInfoId));

            _context.SaveChanges();
        }

        public int AddNewProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product.Id;
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        IQueryable<Product> IProductRepository.GetAllProducts()
        {
            return _context.Products.AsNoTracking();
        }
    }
}
