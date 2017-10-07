using SellAndBuy.Data.Models;
using SellAndBuy.Data.Repositories;
using SellAndBuy.Data.UnitOfWork;
using SellAndBuy.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBuy.Services
{
    public class AddsServices: IAddsService
    {
        private readonly IEfRepository<Add> adds;
        private readonly IEfUnitOfWork context;

        public AddsServices(IEfRepository<Add> adds, IEfUnitOfWork context)
        {
            this.adds = adds;
            this.context = context;
        }
        public ICollection<Add> GetAll()
        {
            return this.adds.All.ToList();
        }
    }
}
