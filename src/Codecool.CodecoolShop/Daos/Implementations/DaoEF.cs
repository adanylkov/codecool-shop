using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Daos.Implementations;

public class DaoEF<T> : IDao<T> where T : class
{
    protected readonly DbContext db;
    protected readonly DbSet<T> dbSet;

    public DaoEF(DbContext db)
    {
        this.db = db;
        dbSet = db.Set<T>();
    }


    public void Add(T item)
    {
        dbSet.Add(item);
        db.SaveChanges();
    }

    public T Get(int id)
    {
        return dbSet.Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return dbSet;
    }

    public void Remove(int id)
    {
        var item = dbSet.Find(id);
        dbSet.Remove(item);
        db.SaveChanges();
    }
}
