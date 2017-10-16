    using Microsoft.AspNet.Identity.EntityFramework;
using SellAndBuy.Data.Models;
using System.Data.Entity;

namespace SellAndBuy.Data
{
    public class SqlDbContext : IdentityDbContext<User>,ISqlDbContext
    {
        public SqlDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }
        public virtual IDbSet<City> Cities { get; set; }
        public virtual IDbSet<Add> Adds { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
        
        public virtual IDbSet<Province> Provinces { get; set; }
        IDbSet<T> ISqlDbContext.Set<T>()
        {
            return this.Set<T>();
        }

        public static SqlDbContext Create()
        {
            return new SqlDbContext();
        }
    }
}
