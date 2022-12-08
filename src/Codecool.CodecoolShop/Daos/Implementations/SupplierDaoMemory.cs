using System.Collections.Generic;
using Domain;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class SupplierDaoMemory : ISupplierDao
    {
        private List<Supplier> data = new();
        public SupplierDaoMemory()
        {
            Add(new Supplier
            {
                Name = "Amazon",
                Description = "Digital content and services"
            });
            Add(new Supplier
            {
                Name = "Lenovo",
                Description = "Computers"
            });
            Add(new Supplier
            {
                Name = "Asus",
                Description = "Computers"
            });
            Add(new Supplier
            {
                Name = "Samsung",
                Description = "Mobile Phones"
            });
            Add(new Supplier
            {
                Name = "Apple",
                Description = "Mobile Phones and Computers"
            });
            Add(new Supplier
            {
                Name = "GeForce",
                Description = "Graphics card "
            });
        }

        public void Add(Supplier item)
        {
            item.Id = data.Count + 1;
            data.Add(item);
        }

        public void Remove(int id)
        {
            data.Remove(Get(id));
        }

        public Supplier Get(int id)
        {
            return data.Find(x => x.Id == id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return data;
        }
    }
}
