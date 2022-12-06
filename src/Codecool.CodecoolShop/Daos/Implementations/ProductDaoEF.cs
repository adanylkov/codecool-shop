using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.CodecoolShop.Daos.Implementations;

public class ProductDaoEF : DaoEF<Product>, IProductDao
{
    public ProductDaoEF(DbContext db) : base(db)
    {
    }

    public IEnumerable<Product> GetBy(Supplier supplier)
    {
        return dbSet.Where(product => product.Supplier == supplier);
    }

    public IEnumerable<Product> GetBy(ProductCategory productCategory)
    {
        return dbSet.Where(product => product.ProductCategory == productCategory);
    }
}
