using DataAccess;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.CodecoolShop.Daos.Implementations;

public class ProductDaoEF : IProductDao
{
    private readonly ShopContext _shopContext;

    public ProductDaoEF(ShopContext shopContext)
    {
        _shopContext = shopContext;
    }
    public void Add(Product item)
    {
        _shopContext.Products.Add(item);
    }

    public Product Get(int id)
    {
        return _shopContext.Products.Find(id);
    }

    public IEnumerable<Product> GetAll()
    {
        return _shopContext.Products;
    }

    public IEnumerable<Product> GetBy(Supplier supplier)
    {
        return _shopContext.Products.Where(product => product.Supplier == supplier);
    }

    public IEnumerable<Product> GetBy(ProductCategory productCategory)
    {
        return _shopContext.Products.Where(product => product.ProductCategory == productCategory);
    }

    public void Remove(int id)
    {
        _shopContext.Remove(id);
    }
}
