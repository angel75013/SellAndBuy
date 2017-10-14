using SellAndBuy.Data.Models;
using SellAndBuy.Data.Repositories;
using SellAndBuy.Data.UnitOfWork;
using SellAndBuy.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;

namespace SellAndBuy.Services
{
    public class CategoriesServices:ICategoriesServices
    {
        private readonly IEfRepository<Category> categories;
        private readonly IEfUnitOfWork context;

        public CategoriesServices(IEfRepository<Category> categories, IEfUnitOfWork context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(categories, "categories").IsNull().Throw();

            this.categories = categories;
            this.context = context;
        }
        public IQueryable<Category> GetAll()
        {
            return this.categories.All;
        }
        public int GetId(string categorie)
        {
            return categories.All.FirstOrDefault(x => x.CategorieName == categorie).Id;
        }
    }
}
