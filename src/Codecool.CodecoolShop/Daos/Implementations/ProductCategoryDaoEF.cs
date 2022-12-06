using DataAccess;
using Domain;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class ProductCategoryDaoEF : IProductCategoryDao
    {
        private readonly ShopContext _shopContext;

        public ProductCategoryDaoEF(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public void Add(ProductCategory item)
        {
            _shopContext.ProductCategories.Add(item);
            _shopContext.SaveChanges();
        }

        public ProductCategory Get(int id)
        {
            return _shopContext.ProductCategories.Find(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _shopContext.ProductCategories;
        }

        public void Remove(int id)
        {
            var item = Get(id);
            _shopContext.ProductCategories.Remove(item);
            _shopContext.SaveChanges();
        }
    }
}
