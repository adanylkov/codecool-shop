using Domain;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Services
{
    public interface IProductService
    {
        IEnumerable<ProductCategory> GetCategories();
        Product GetProductById(int productId);
        ProductCategory GetProductCategory(int categoryId);
        IEnumerable<Product> GetProductsForCategory(int categoryId);
        IEnumerable<Product> GetProductsForSupplier(int supplierId);
        IEnumerable<Supplier> GetSupliers();
    }
}