using System.Collections.Generic;
using Domain;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    class ProductCategoryDaoMemory : IProductCategoryDao
    {
        private List<ProductCategory> data = new();
        public ProductCategoryDaoMemory()
        {
            Add(new ProductCategory
            {
                Name = "Tablet",
                Department = "Hardware",
                Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display."
            });
            Add(new ProductCategory
            {
                Name = "Laptop",
                Department = "Hardware",
                Description = "A laptop computer is a battery- or AC-powered personal computer"
            });
            Add(new ProductCategory
            {
                Name = "Graphics card",
                Department = "Hardware",
                Description = "A Graphics card is an expansion card which generates a feed of output images to a display device, such as a computer monitor."
            });
            Add(new ProductCategory
            {
                Name = "Mobile Phone",
                Department = "Hardware",
                Description = "a telephone with access to a cellular radio system so it can be used over a wide area, without a physical connection to a network."
            });
        }
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
