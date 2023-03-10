using System;
using System.Collections.Generic;
using Codecool.CodecoolShop.Daos;
using Domain;

namespace Codecool.CodecoolShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDao productDao;
        private readonly IProductCategoryDao productCategoryDao;
        private readonly ISupplierDao supplierDao;

        public ProductService(IProductDao productDao, IProductCategoryDao productCategoryDao, ISupplierDao supplierDao)
        {
            this.productDao = productDao;
            this.productCategoryDao = productCategoryDao;
            this.supplierDao = supplierDao;
        }

        public Product GetProductById(int productId)
        {
            return productDao.Get(productId);
        }
        public ProductCategory GetProductCategory(int categoryId)
        {
            return productCategoryDao.Get(categoryId);
        }

        public IEnumerable<Product> GetProductsForCategory(int categoryId)
        {
            ProductCategory category = productCategoryDao.Get(categoryId);
            return productDao.GetBy(category);
        }
        public IEnumerable<Product> GetProductsForSupplier(int supplierId)
        {
            Supplier supplier = supplierDao.Get(supplierId);
            return productDao.GetBy(supplier);
        }
        public IEnumerable<ProductCategory> GetCategories()
        {
            return productCategoryDao.GetAll();
        }

        public IEnumerable<Supplier> GetSupliers()
        {
            return supplierDao.GetAll();
        }
    }
}
