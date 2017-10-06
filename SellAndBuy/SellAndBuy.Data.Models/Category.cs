﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBuy.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Adds = new HashSet<Add>();
           
        }
        public int Id { get; set; }
       
        public CategoriesEnum CategorieName { get; set; }
       
        public virtual ICollection<Add> Adds { get; set; }
    }
}
