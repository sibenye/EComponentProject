﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComponent.DataAccess.DataModels
{
    public class ProductPrice : BaseModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }
    }
}
