using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using solution_file.Models;

namespace solution_file.DataAccess.Data
{
    public class WebAppDbContext : IdentityDbContext<IdentityUser>
    {
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base(options)
        {

            
        }
        public DbSet<Category> ShoppingCart { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
         new Category { Id = 1, Name = "Electronics", DisplayOrder = 1 },
         new Category { Id = 2, Name = "Clothing", DisplayOrder = 2 },
         new Category { Id = 3, Name = "Accessories", DisplayOrder = 3 }
     );
            modelBuilder.Entity<Company>().HasData(
             new Company { Id = 1, Name = "Tech Solution", StreetAddress="123 Tech St", City="Tech City",
                 PostalCode="12121", State="IL", PhoneNumber ="6669990000"},
              new Company
              {
                  Id = 2,
                  Name = "Tech Solution2",
                  StreetAddress = "123 Tech St2",
                  City = "Tech Cit2",
                  PostalCode = "121212",
                  State = "IL2",
                  PhoneNumber = "6669990001"
              },
               new Company
               {
                   Id = 3,
                   Name = "Tech Solution3",
                   StreetAddress = "123 Tech St3",
                   City = "Tech City3",
                   PostalCode = "121213",
                   State = "IL3",
                   PhoneNumber = "6669990003"
               }

             );
            modelBuilder.Entity<Product>().HasData(
        new Product
        {
            Id = 1,
            Title = "Apple iPad",
            Producer = "Apple Inc.",
            Description = "A sleek, powerful tablet suitable for work, reading, or entertainment.",
            ProductCode = "APP-IPD-001", // reusing ProductCode field as a 'SKU/ModelNo'
            ListPrice = 499,
            Price = 450,
            Price50 = 400,
            Price100 = 350,
            CategoryId = 1, // Electronics
            ImageUrl = ""    // update with a real image path if you have one
        },
        new Product
        {
            Id = 2,
            Title = "Samsung 55-inch TV",
            Producer = "Samsung",
            Description = "Experience vivid colors and crisp detail on a 55-inch smart TV.",
            ProductCode = "SAM-TV-55",
            ListPrice = 799,
            Price = 750,
            Price50 = 700,
            Price100 = 650,
            CategoryId = 1, // Electronics
            ImageUrl = ""
        },
        new Product
        {
            Id = 3,
            Title = "Men's Cotton T-Shirt",
            Producer = "Generic",
            Description = "A comfortable 100% cotton T-shirt available in various sizes.",
            ProductCode = "TSHIRT-0001",
            ListPrice = 20,
            Price = 18,
            Price50 = 16,
            Price100 = 14,
            CategoryId = 2, // Clothing
            ImageUrl = ""
        },
        new Product
        {
            Id = 4,
            Title = "Women's Denim Jeans",
            Producer = "DenimCo",
            Description = "Classic denim jeans designed with comfort and style in mind.",
            ProductCode = "JEANS-0002",
            ListPrice = 40,
            Price = 35,
            Price50 = 30,
            Price100 = 25,
            CategoryId = 2, // Clothing
            ImageUrl = ""
        },
        new Product
        {
            Id = 5,
            Title = "Wireless Headphones",
            Producer = "AudioBrand",
            Description = "Noise-canceling over-ear headphones with premium sound quality.",
            ProductCode = "AUD-HD-999",
            ListPrice = 99,
            Price = 85,
            Price50 = 75,
            Price100 = 60,
            CategoryId = 1, // Electronics
            ImageUrl = ""
        },
        new Product
        {
            Id = 6,
            Title = "Leather Wallet",
            Producer = "FashionBrand",
            Description = "A durable leather wallet with multiple card slots and a sleek design.",
            ProductCode = "LWALLET-450",
            ListPrice = 35,
            Price = 30,
            Price50 = 25,
            Price100 = 20,
            CategoryId = 3, // Accessories
            ImageUrl = ""
        }
    );
        }
    }
}
