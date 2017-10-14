using SellAndBuy.Data.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SellAndBuy.Data
{
    public interface ISqlDbContext
    {
        IDbSet<City> Cities { get; set; }
        IDbSet<Add> Adds { get; set; }
        IDbSet<Category> Categories { get; set; }
        IDbSet<Province> Provinces { get; set; }

        IDbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}