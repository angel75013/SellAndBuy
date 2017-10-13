﻿using SellAndBuy.Data.Models;
using SellAndBuy.Services.Contracts.Commun;
using System.Collections.Generic;
using System.Linq;

namespace SellAndBuy.Services.Contracts
{
    public interface ICategoriesServices : IService,IBaseService<Category>, IGeoService
    { 
    }
}