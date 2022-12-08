using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ShopContext : IdentityDbContext
{
    private const string _connectionString = "Data Source=localhost;Database=CodecoolShop;Integrated Security=true";

    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public ShopContext() : base()
    {
    }
    public ShopContext(DbContextOptions<ShopContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var amazon = new Supplier { Id = 1, Name = "Amazon", Description = "Digital content and services" };
        var lenovo = new Supplier { Id = 2, Name = "Lenovo", Description = "Computers" };
        var asus = new Supplier { Id = 3, Name = "Asus", Description = "Computers" };
        var samsung = new Supplier { Id = 4, Name = "Samsung", Description = "Mobile Phones" };
        var apple = new Supplier { Id = 5, Name = "Apple", Description = "Mobile Phones and Computers" };
        var geForce = new Supplier { Id = 6, Name = "GeForce", Description = "Graphics card " };

        modelBuilder.Entity<Supplier>().HasData(amazon);
        modelBuilder.Entity<Supplier>().HasData(lenovo);
        modelBuilder.Entity<Supplier>().HasData(asus);
        modelBuilder.Entity<Supplier>().HasData(samsung);
        modelBuilder.Entity<Supplier>().HasData(apple);
        modelBuilder.Entity<Supplier>().HasData(geForce);

        var tablet = new ProductCategory { Id = 1, Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
        var laptop = new ProductCategory { Id = 2, Name = "Laptop", Department = "Hardware", Description = "A laptop computer is a battery- or AC-powered personal computer" };
        var graphicsCard = new ProductCategory { Id = 3, Name = "Graphics card", Department = "Hardware", Description = "A Graphics card is an expansion card which generates a feed of output images to a display device, such as a computer monitor." };
        var mobilePhone = new ProductCategory { Id = 4, Name = "Mobile Phone", Department = "Hardware", Description = "a telephone with access to a cellular radio system so it can be used over a wide area, without a physical connection to a network." };

        modelBuilder.Entity<ProductCategory>().HasData(tablet);
        modelBuilder.Entity<ProductCategory>().HasData(laptop);
        modelBuilder.Entity<ProductCategory>().HasData(graphicsCard);
        modelBuilder.Entity<ProductCategory>().HasData(mobilePhone);


        modelBuilder.Entity<Product>().HasData(new Product { Id = 1, Name = "Amazon Fire", DefaultPrice = 49.9m, Currency = "USD", Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.", ProductCategoryId = tablet.Id, SupplierId = amazon.Id });
        modelBuilder.Entity<Product>().HasData(new Product { Id = 2, Name = "Lenovo IdeaPad Miix 700", DefaultPrice = 479.0m, Currency = "USD", Description = "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.", ProductCategoryId = tablet.Id, SupplierId = lenovo.Id });
        modelBuilder.Entity<Product>().HasData(new Product { Id = 3, Name = "Amazon Fire HD 8", DefaultPrice = 89.0m, Currency = "USD", Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", ProductCategoryId = tablet.Id, SupplierId = amazon.Id });
        modelBuilder.Entity<Product>().HasData(new Product { Id = 4, Name = "ASUS TUF Gaming", DefaultPrice = 650.0m, Currency = "USD", Description = "Bristling with high-refresh rate displays and competitive GPUs, ultra-durable TUF Gaming laptop deliver a reliable portable gaming experience to a wide audience of gamers.", ProductCategoryId = laptop.Id, SupplierId = asus.Id });
        modelBuilder.Entity<Product>().HasData(new Product { Id = 5, Name = "Geforce RTX 3070", DefaultPrice = 510.0m, Currency = "USD", Description = "The Nvidia GeForce RTX 3070 is a fast desktop graphics card based on the Ampere architecture", ProductCategoryId = graphicsCard.Id, SupplierId = geForce.Id });
        modelBuilder.Entity<Product>().HasData(new Product { Id = 6, Name = "Samsung Galaxy S22", DefaultPrice = 610.0m, Currency = "USD", Description = "Samsung Galaxy S22, the most affordable device in the company's 2022 flagship series, has flown under the radar", ProductCategoryId = mobilePhone.Id, SupplierId = samsung.Id });
        modelBuilder.Entity<Product>().HasData(new Product { Id = 7, Name = "Iphone 14", DefaultPrice = 1115.0m, Currency = "USD", Description = "Iphone 14 has A15 Bionic, with a 5‑core GPU, powers all the latest features and makes graphically intense games and AR apps feel ultrafluid.", ProductCategoryId = mobilePhone.Id, SupplierId = apple.Id });
        modelBuilder.Entity<Product>().HasData(new Product { Id = 8, Name = "ASUS ROG Phone 6", DefaultPrice = 999.0m, Currency = "USD", Description = "The ASUS ROG Phone 6 is an Android gaming smartphone made by Asus", ProductCategoryId = mobilePhone.Id, SupplierId = asus.Id });
    }
}