﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }
    }
}
