using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Daos.Implementations;

public class ProductCategoryDaoEF : DaoEF<ProductCategory>, IProductCategoryDao
{
    public ProductCategoryDaoEF(ShopContext db) : base(db) { }
}
