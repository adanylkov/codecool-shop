using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ShopContext : DbContext
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
}