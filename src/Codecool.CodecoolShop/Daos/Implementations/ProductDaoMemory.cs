using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class ProductDaoMemory : IProductDao
    {
        private readonly List<Product> data = new();

        public ProductDaoMemory(IProductCategoryDao productCategoryDao, ISupplierDao supplierDao)
        {
            var tablet = productCategoryDao.GetAll().FirstOrDefault(c => c.Name == "Tablet");
            var amazon = supplierDao.GetAll().FirstOrDefault(c => c.Name == "Amazon");
            var lenovo = supplierDao.GetAll().FirstOrDefault(c => c.Name == "Lenovo");
            var laptop = productCategoryDao.GetAll().FirstOrDefault(c => c.Name == "Laptop");
            var asus = supplierDao.GetAll().FirstOrDefault(c => c.Name == "Asus");
            var graphicsCard = productCategoryDao.GetAll().FirstOrDefault(c => c.Name == "Graphics card");
            var geForce = supplierDao.GetAll().FirstOrDefault(s => s.Name == "GeForce");
            var mobilePhone = productCategoryDao.GetAll().FirstOrDefault(c => c.Name == "Mobile Phone");
            var samsung = supplierDao.GetAll().FirstOrDefault(s => s.Name == "Samsung");
            var apple = supplierDao.GetAll().FirstOrDefault(s => s.Name == "Apple");

            Add(new Product
            {
                Name = "Amazon Fire",
                DefaultPrice = 49.9m,
                Currency = "USD",
                Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.",
                ProductCategory = tablet,
                ProductCategoryId = tablet.Id,
                Supplier = amazon,
                SupplierId = amazon.Id,
            });
            Add(new Product
            {
                Name = "Lenovo IdeaPad Miix 700",
                DefaultPrice = 479.0m,
                Currency = "USD",
                Description = "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.",
                ProductCategory = tablet,
                ProductCategoryId = tablet.Id,
                Supplier = lenovo,
                SupplierId = lenovo.Id,
            });
            Add(new Product
            {
                Name = "Amazon Fire HD 8",
                DefaultPrice = 89.0m,
                Currency = "USD",
                Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.",
                ProductCategory = tablet,
                ProductCategoryId = tablet.Id,
                Supplier = amazon,
                SupplierId = amazon.Id,
            });
            Add(new Product
            {
                Name = "ASUS TUF Gaming",
                DefaultPrice = 650.0m,
                Currency = "USD",
                Description = "Bristling with high-refresh rate displays and competitive GPUs, ultra-durable TUF Gaming laptop deliver a reliable portable gaming experience to a wide audience of gamers.",
                ProductCategory = laptop,
                ProductCategoryId = laptop.Id,
                Supplier = asus,
                SupplierId = asus.Id,
            });
            Add(new Product
            {
                Name = "Geforce RTX 3070",
                DefaultPrice = 510.0m,
                Currency = "USD",
                Description = "The Nvidia GeForce RTX 3070 is a fast desktop graphics card based on the Ampere architecture",
                ProductCategory = graphicsCard,
                ProductCategoryId = graphicsCard.Id,
                Supplier = geForce,
                SupplierId = geForce.Id,
            });
            Add(new Product
            {
                Name = "Samsung Galaxy S22",
                DefaultPrice = 610.0m,
                Currency = "USD",
                Description = "Samsung Galaxy S22, the most affordable device in the company's 2022 flagship series, has flown under the radar",
                ProductCategory = mobilePhone,
                ProductCategoryId = mobilePhone.Id,
                Supplier = samsung,
                SupplierId = samsung.Id,
            });
            Add(new Product
            {
                Name = "Iphone 14",
                DefaultPrice = 1115.0m,
                Currency = "USD",
                Description = "Iphone 14 has A15 Bionic, with a 5‑core GPU, powers all the latest features and makes graphically intense games and AR apps feel ultrafluid.",
                ProductCategory = mobilePhone,
                ProductCategoryId = mobilePhone.Id,
                Supplier = apple,
                SupplierId = apple.Id,
            });
            Add(new Product
            {
                Name = "ASUS ROG Phone 6",
                DefaultPrice = 999.0m,
                Currency = "USD",
                Description = "The ASUS ROG Phone 6 is an Android gaming smartphone made by Asus",
                ProductCategory = mobilePhone,
                ProductCategoryId = mobilePhone.Id,
                Supplier = asus,
                SupplierId = asus.Id,
            });
        }
        public void Add(Product item)
        {
            item.Id = data.Count + 1;
            data.Add(item);
        }

        public void Remove(int id)
        {
            data.Remove(Get(id));
        }

        public Product Get(int id)
        {
            return data.Find(x => x.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return data;
        }

        public IEnumerable<Product> GetBy(Supplier supplier)
        {
            return data.Where(x => x.SupplierId == supplier.Id);
        }

        public IEnumerable<Product> GetBy(ProductCategory productCategory)
        {
            return data.Where(x => x.ProductCategoryId == productCategory.Id);
        }
    }
}
