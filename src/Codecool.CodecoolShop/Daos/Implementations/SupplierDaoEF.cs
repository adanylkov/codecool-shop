using DataAccess;
using Domain;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class SupplierDaoEF : ISupplierDao
    {
        private readonly ShopContext _shopContext;
        public void Add(Supplier item)
        {
            _shopContext.Suppliers.Add(item);
            _shopContext.SaveChanges();
        }

        public Supplier Get(int id)
        {
            return _shopContext.Suppliers.Find(id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _shopContext.Suppliers;
        }

        public void Remove(int id)
        {
            var item = Get(id); 
            _shopContext.Suppliers.Remove(item);
            _shopContext.SaveChanges();
        }
    }
}
