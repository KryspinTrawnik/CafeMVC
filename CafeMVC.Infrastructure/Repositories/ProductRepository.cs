using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CafeMVC.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _context;

        public ProductRepository(DbContext context)
        {
            _context = context;
        }
            ///*** Product Actions***\\\
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
        public Product GetProductById(int productId)
        {
            var product = _context.Products.AsNoTracking()
                .Include(x => x.ProductIngredients)
                .Include(x => x.ProductAllergens)
                .Include(x => x.ProductDietInfoTags)
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
            _context.Entry(product).Collection("ProductIngredients");
            _context.Entry(product).Collection("ProductAllergens");
            _context.Entry(product).Collection("ProductDietInfoTags");
            _context.SaveChanges();
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
        ///***Ingredient Actions***///
        public void AddIngredientToProduct(ProductIngredient productIngredient)
        {
            var product = GetProductById(productIngredient.ProductId);
            product.ProductIngredients.Add(productIngredient);
            UpdateProduct(product);
        }
        public IQueryable<ProductIngredient> GetAllProductIngredients(int productId)
        {
            return _context.Products.AsNoTracking().Include(x => x.ProductIngredients)
                .FirstOrDefault(x => x.Id == productId).ProductIngredients.AsQueryable();

        }
        public void RemoveIngredientFromProduct(ProductIngredient productIngredientToBeRemoved)
        {
            _context.ProductIngredients.Remove(productIngredientToBeRemoved);
            _context.SaveChanges();
            
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
        public void DeleteIngredient(int ingredientId)
        {
            _context.Ingredients.Remove(GetIngredientById(ingredientId));
            _context.SaveChanges();
        }

        ///***Allergens Actions***///
        public void AddAllergenToProduct(ProductAllergen productAllergen)
        {
            var product = GetProductById(productAllergen.ProductId);
            product.ProductAllergens.Add(productAllergen);
            UpdateProduct(product);
        }


        public IQueryable<ProductAllergen> GetAllAllergensFromProduct(int productId)
        {

            return _context.Products.AsNoTracking().Include(x => x.ProductAllergens)
                .FirstOrDefault(x => x.Id == productId).ProductAllergens.AsQueryable();
        }

        public void RemoveAllergenFromProduct(ProductAllergen productAllergenToBeRemoved)
        {
            _context.ProductAllergens.Remove(productAllergenToBeRemoved);
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


        public void AddNewAllergen(Allergen allergen)
        {
            _context.Allergens.Add(allergen);
            _context.SaveChanges();
        }
        ///***Diet info Actions***///

        public void AddDietInfoToProduct(ProductDietInfoTag productDietInfoTag )
        {
            _context.ProductDietInfoTags.Add(productDietInfoTag);
            _context.SaveChanges();

        }

        public IQueryable<DietInfoTag> GetAllDietInfo()
        {
            return _context.DietInfotags.AsNoTracking();
        }

        public IQueryable<ProductDietInfoTag> GetAllProductDietInfo(int productId)
        {
            return _context.ProductDietInfoTags.Where(x => x.ProductId ==productId).AsQueryable();

        }

        public void RemoveDietInfoFromProduct(ProductDietInfoTag productDietInfoTagToBeRemoved)
        {
            _context.ProductDietInfoTags.Remove(productDietInfoTagToBeRemoved);
            _context.SaveChanges();
        }

        public DietInfoTag GetDietInfoTagById(int dietInfoTagId)
        {
            return _context.DietInfotags.FirstOrDefault(x => x.Id == dietInfoTagId);
        }
    }
}
