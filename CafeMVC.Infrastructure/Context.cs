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

        public DbSet<ContactDetailType> ContactDetailTypes { get; set; }

        public DbSet<DietInformation> DietInformations { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }
    
        public DbSet<ContactDetail> ContactDetails { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Address>()
            //    .HasOne<AddressType>()
            //    .WithMany(a => a.Addresses)
            //    .HasForeignKey(s => s.AddressTypeId);

            //builder.Entity<ContactDetail>()
            //    .HasOne<ContactDetailType>()
            //    .WithMany(a => a.ContactDetails)
            //    .HasForeignKey(s => s.ContactDetailTypeId);

            //builder.Entity<Address>()
            //    .HasOne<Customer>()
            //    .WithMany(g => g.Addresses)
            //    .HasForeignKey(s => s.CustomerId);

            //builder.Entity<ContactDetail>()
            //    .HasOne<Customer>()
            //    .WithMany(g => g.ContactDetails)
            //    .HasForeignKey(s => s.CustomerId);

            builder.Entity<ContactDetailType>()
                .HasData(new ContactDetailType { Id = 1, Name = "E-mail" },
                new ContactDetailType { Id = 2, Name = "Mobile Number" },
                new ContactDetailType { Id = 3, Name = "Home Number" });

            builder.Entity<AddressType>()
                .HasData(new AddressType { Id = 1, Name = "Billing Address" },
                new AddressType { Id = 2, Name = "Delivery Address" });

            builder.Entity<Status>()
                .HasData(new Status { Id = 2, Name = "In Progress" },
                new Status { Id = 3, Name = "Closed" },
                new Status { Id = 4, Name = "Cancelled" },
                new Status { Id = 1, Name = "Open" });
        }

    }
}
