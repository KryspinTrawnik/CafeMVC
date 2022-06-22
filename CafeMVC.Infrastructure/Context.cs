using CafeMVC.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CafeMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Address> Adresses { get; set; }

        public DbSet<AddressType> AddressTypes { get; set; }

        public DbSet<Allergen> Allergens { get; set; }

        public DbSet<ContactDetailType> ContactDetailTypes { get; set; }

        public DbSet<DietInfoTag> DietInfotags { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<ContactDetail> ContactDetails { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<ProductIngredient> ProductIngredients { get; set; }

        public DbSet<ProductAllergen> ProductAllergens { get; set; }

        public DbSet<ProductDietInfoTag> ProductDietInfoTags { get; set; }

        public DbSet<OrderContactDetail> OrderContactDetails { get; set; }

        public DbSet<OrderAddress> OrderAddresses { get; set; }

        public DbSet<OrderedProductDetails> OrderedProductDetails { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Menu>()
                .HasMany(m => m.Products)
                .WithOne(p => p.Menu)
                .HasForeignKey(p =>p.MenuId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<ProductIngredient>().HasKey(pi => new { pi.ProductId, pi.IngredientId });

            builder.Entity<ProductIngredient>().HasOne<Product>(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);

            builder.Entity<ProductIngredient>()
                .HasOne<Ingredient>(pi => pi.Ingredient)
                .WithMany(i => i.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId)
                .IsRequired();

            builder.Entity<ProductAllergen>().HasKey(pa => new { pa.ProductId, pa.AllergenId });

            builder.Entity<ProductAllergen>()
                .HasOne<Product>(pa => pa.Product)
                .WithMany(p => p.ProductAllergens)
                .HasForeignKey(pa => pa.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductAllergen>()
                .HasOne<Allergen>(pa => pa.Allergen)
                .WithMany(a => a.ProductAllergens)
                .HasForeignKey(pa => pa.AllergenId)
                .IsRequired();

            builder.Entity<ProductDietInfoTag>().HasKey(pp => new { pp.ProductId, pp.DietInfoTagId });

            builder.Entity<ProductDietInfoTag>()
               .HasOne<Product>(pp => pp.Product)
               .WithMany(p => p.ProductDietInfoTags)
               .HasForeignKey(pp => pp.ProductId)
               .IsRequired();

            builder.Entity<ProductDietInfoTag>()
            .HasOne<DietInfoTag>(pp => pp.DietInfoTag)
            .WithMany(a => a.ProductDietInfoTags)
            .HasForeignKey(pp => pp.DietInfoTagId)
            .IsRequired();

            builder.Entity<OrderContactDetail>().HasKey(oc => new { oc.OrderId, oc.ContactDetailId });

            builder.Entity<OrderContactDetail>()
                .HasOne<Order>(oc => oc.Order)
                .WithMany(o => o.OrderContactDetails)
                .HasForeignKey(oc => oc.OrderId)
                .IsRequired();

            builder.Entity<OrderContactDetail>()
                .HasOne<ContactDetail>(oc => oc.ContactDetail)
                .WithMany(cd => cd.OrderContactDetails)
                .HasForeignKey(oc => oc.ContactDetailId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OrderAddress>().HasKey(oa => new { oa.OrderId, oa.AddressId });

            builder.Entity<OrderAddress>()
                .HasOne<Order>(oa => oa.Order)
                .WithMany(o => o.OrderAddresses)
                .HasForeignKey(oa => oa.OrderId)
                .IsRequired();

            builder.Entity<OrderAddress>()
                .HasOne<Address>(cd => cd.Address)
                .WithMany(a => a.OrderAddresses)
                .HasForeignKey(oa => oa.AddressId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<ContactDetailType>()
                .HasData(new ContactDetailType { Id = 1, Name = "E-mail" },
                new ContactDetailType { Id = 2, Name = "Mobile Number" },
                new ContactDetailType { Id = 3, Name = "Home Number" });

            builder.Entity<AddressType>()
                .HasData(new AddressType { Id = 1, Name = "Billing Address" },
                new AddressType { Id = 2, Name = "Delivery Address" });

            builder.Entity<Status>()
                .HasData(
                    new Status { Id = 1, Name = "Open" },
                    new Status { Id = 2, Name = "In Progress" },
                    new Status { Id = 3, Name = "Ready" },
                    new Status { Id = 4, Name = "Closed" },
                    new Status { Id = 5, Name = "Cancelled" });
        }

    }
}
