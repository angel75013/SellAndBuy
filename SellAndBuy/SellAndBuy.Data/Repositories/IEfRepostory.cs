using System.Linq;

namespace SellAndBuy.Data.Repositories
{
    public interface IEfRepository<T>
    where T : class
    {
        IQueryable<T> All { get; }      

        void Add(T entity);

        void Delete(T entity);
            
        //void Update(T entity); if edit implement
    }
}