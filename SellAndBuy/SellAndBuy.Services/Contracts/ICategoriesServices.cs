using SellAndBuy.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SellAndBuy.Services.Contracts
{
    public interface ICategoriesServices : IService
    {
        IQueryable<Category> GetAll();
        int GetId(string str);

    }
}