using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.CodecoolShop.Daos.Implementations;

public class ProductDaoEF : DaoEF<Product>, IProductDao
{
    public ProductDaoEF(ShopContext db) : base(db)
    {
    }

    public IEnumerable<Product> GetBy(Supplier supplier)
    {
        return dbSet.Where(product => product.SupplierId == supplier.Id);
    }

    public IEnumerable<Product> GetBy(ProductCategory productCategory)
    {
        return dbSet.Where(product => product.ProductCategoryId == productCategory.Id);
    }
}
