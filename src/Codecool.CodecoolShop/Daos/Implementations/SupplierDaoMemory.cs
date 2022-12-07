using System.Collections.Generic;
using Domain;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class SupplierDaoMemory : ISupplierDao
    {
        private List<Supplier> data = new List<Supplier>();

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
