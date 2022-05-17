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
        ///*** Product Actions***\\\
        public int AddNewProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product.Id;
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public IQueryable<Product> GetAllProducts() => _context.Products.AsNoTrackingWithIdentityResolution();
            //.Include(x => x.Menu).AsNoTracking()
            //.Include(x => x.ProductIngredients)
            //    .ThenInclude(x => x.Ingredient).AsNoTracking()
            // .Include(x => x.ProductAllergens)
            //     .ThenInclude(x => x.Allergen).AsNoTracking()
            // .Include(x => x.ProductDietInfoTags)
            //     .ThenInclude(x => x.DietInfoTag).AsNoTracking();
        public Product GetProductById(int productId)
        {
            Product product = _context.Products
                //.Include(x => x.Menu).AsNoTracking()
                //.Include(x => x.ProductIngredients)
                //    .ThenInclude(x => x.Ingredient).AsNoTracking()
                //.Include(x => x.ProductAllergens)
                //    .ThenInclude(x => x.Allergen).AsNoTracking()
                //.Include(x => x.ProductDietInfoTags)
                //    .ThenInclude(x => x.DietInfoTag).AsNoTracking()
                .FirstOrDefault(x => x.Id == productId);
            
            return product;
        }

        public void UpdateProduct(Product product)
        {
            // _context.Attach(product);
            _context.Entry(product).Property("Name").IsModified = true;
            _context.Entry(product).Property("Price").IsModified = true;
            _context.Entry(product).Property("Description").IsModified = true;
            _context.Entry(product).Property("MenuId").IsModified = true;
            _context.Entry(product).Property("ImagePath").IsModified = true;
            _context.Entry(product).Collection("ProductIngredients").IsModified = true;
            _context.Entry(product).Collection("ProductAllergens").IsModified = true;
            _context.Entry(product).Collection("ProductDietInfoTags").IsModified = true;
            _context.SaveChanges();
        }

        ///***Ingredient Actions***///
        public void AddIngredientToProduct(ProductIngredient productIngredient)
        {
            _context.ProductIngredients.Add(productIngredient);
            _context.SaveChanges();
        }
        public IQueryable<ProductIngredient> GetAllProductIngredients(int productId)
        => _context.ProductIngredients.Where(x => x.ProductId == productId).AsQueryable();

        public void RemoveIngredientFromProduct(ProductIngredient productIngredientToBeRemoved)
        {
            _context.ProductIngredients.Remove(productIngredientToBeRemoved);
            _context.SaveChanges();

        }

        public Ingredient GetIngredientById(int ingredientId) => _context.Ingredients.Find(ingredientId);

        public IQueryable<Ingredient> GetAllIngredients() => _context.Ingredients;

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
            _context.ProductAllergens.Add(productAllergen);
            _context.SaveChanges();
        }

        public IQueryable<ProductAllergen> GetAllAllergensFromProduct(int productId)
        => _context.ProductAllergens.Where(x => x.ProductId == productId).AsQueryable();

        public void RemoveAllergenFromProduct(ProductAllergen productAllergenToBeRemoved)
        {
            _context.ProductAllergens.Remove(productAllergenToBeRemoved);
            _context.SaveChanges();
        }

        public Allergen GetAllergenById(int id) => _context.Allergens.Find(id);

        public IQueryable<Allergen> GetAllAllergens() => _context.Allergens.AsNoTracking();

        public void AddNewAllergen(Allergen allergen)
        {
            _context.Allergens.Add(allergen);
            _context.SaveChanges();
        }
        public void DeleteAllergen(int allergenId)
        {
            _context.Allergens.Remove(GetAllergenById(allergenId));
            _context.SaveChanges();
        }
        ///***Diet info Actions***///

        public void AddDietInfoToProduct(ProductDietInfoTag productDietInfoTag)
        {
            _context.ProductDietInfoTags.Add(productDietInfoTag);
            _context.SaveChanges();
        }

        public IQueryable<DietInfoTag> GetAllDietInfo() => _context.DietInfotags.AsNoTracking();

        public IQueryable<ProductDietInfoTag> GetAllProductDietInfo(int productId) => _context.ProductDietInfoTags
            .Where(x => x.ProductId == productId).AsQueryable();

        public void RemoveDietInfoFromProduct(ProductDietInfoTag productDietInfoTagToBeRemoved)
        {
            _context.ProductDietInfoTags.Remove(productDietInfoTagToBeRemoved);
            _context.SaveChanges();
        }

    }
}
