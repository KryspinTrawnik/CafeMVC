using CafeMVC.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CafeMVC.Infrastructure
{
    public class Context : IdentityDbContext 
    {
        public DbSet <Address> Adresses { get; set; }

        public DbSet <AddressType> AddressTypes { get; set; }

        public DbSet<Allergen> Allergens { get; set; }

        public DbSet<ContactDetailInfotmationType> ContactDetailInfotmationTypes { get; set; }

        public DbSet<DietInformation> DietInformation { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserContactInformation> UserContactInformation { get; set; }


        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>()
                .HasOne(a => a.AddressType).WithOne(b => b.Address)
                .HasForeignKey<AddressType>(c => c.AddersRef);

            builder.Entity<UserContactInformation>()
                .HasOne(a => a.ContactDetailInfotmationType).WithOne(b => b.UserContactInformation)
                .HasForeignKey<ContactDetailInfotmationType>(c => c.UserContactInformationRef);
            builder.Entity<Product>()
                .HasOne(a => a.DietInformation).WithOne(b => b.Product)
                .HasForeignKey<DietInformation>(c => c.ProductRef);
            builder.Entity<Product>()
                .HasOne(a => a.ProductType).WithOne(b => b.Product)
                .HasForeignKey<ProductType>(c => c.ProductRef);


            base.OnModelCreating(builder);      
        }

    }
}
