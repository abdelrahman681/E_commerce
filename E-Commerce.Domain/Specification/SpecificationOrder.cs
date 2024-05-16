﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Specification
{
    [JsonConverter(typeof( JsonStringEnumConverter))]
    public enum SpecificationOrder
    {
        NameAsc, NameDesc, PriceAsc , PriceDecs,
    }
}
