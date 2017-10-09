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
    public class ProvincesServices: IProvincesServices
    {
        private readonly IEfRepository<Province> provinces;
        private readonly IEfUnitOfWork context;

        public ProvincesServices(IEfRepository<Province> provinces, IEfUnitOfWork context)
        {
            this.provinces = provinces;
            this.context = context;
        }
        public IQueryable<Province> GetAll()
        {

            return this.provinces.All;
        }
        public int GetId(string province)
        {
            return provinces.All.FirstOrDefault(x => x.ProvinceName == province).Id;
        }
    }
}
