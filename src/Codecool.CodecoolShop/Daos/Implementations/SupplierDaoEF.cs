using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class SupplierDaoEF : DaoEF<Supplier>, ISupplierDao
    {
        public SupplierDaoEF(ShopContext db) : base(db)
        {
        }
    }
}
