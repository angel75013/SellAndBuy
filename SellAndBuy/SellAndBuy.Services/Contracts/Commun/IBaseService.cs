﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBuy.Services.Contracts
{
    public interface IBaseService<T>
    where T : class
    {
        IQueryable<T> GetAll();
    }
}