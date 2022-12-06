using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class SupplierDaoEF : DaoEF<Supplier>, ISupplierDao
    {
        public SupplierDaoEF(ShopContext db) : base(db)
        {
        }
        public IEnumerable<Supplier> GetWithProducts()
        {
            return dbSet.Include(s => s.Products).ToList();
        }
    }
}
