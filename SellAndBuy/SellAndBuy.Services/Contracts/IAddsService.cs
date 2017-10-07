using SellAndBuy.Data.Models;
using System.Collections.Generic;

namespace SellAndBuy.Services.Contracts
{
    public interface IAddsService: IService
    {
        ICollection<Add> GetAll();
    }
}