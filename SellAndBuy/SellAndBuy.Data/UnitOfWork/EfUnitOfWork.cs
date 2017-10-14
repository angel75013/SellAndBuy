using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;

namespace SellAndBuy.Data.UnitOfWork
{
    public class EfUnitOfWork : IEfUnitOfWork
    {
        private readonly ISqlDbContext context;

        public EfUnitOfWork(ISqlDbContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
