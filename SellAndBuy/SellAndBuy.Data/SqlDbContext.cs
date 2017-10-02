using Microsoft.AspNet.Identity.EntityFramework;
using SellAndBuy.Data.Models;

namespace SellAndBuy.Data
{
    public class SqlDbContext : IdentityDbContext<User>
    {
        public SqlDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public static SqlDbContext Create()
        {
            return new SqlDbContext();
        }
    }
}
