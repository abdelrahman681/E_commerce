﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entity
{
    public class ProductType :BaseEntity<int>
    {
        public string Name { get; set; }

        //public List<Product> Product { get; set; }
    }
}
