using System.Collections.Generic;
using Domain;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    class ProductCategoryDaoMemory : IProductCategoryDao
    {
        private List<ProductCategory> data = new List<ProductCategory>();

        public void Add(ProductCategory item)
        {
            item.Id = data.Count + 1;
            data.Add(item);
        }

        public void Remove(int id)
        {
            data.Remove(Get(id));
        }

        public ProductCategory Get(int id)
        {
            return data.Find(x => x.Id == id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return data;
        }
    }
}
