﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluePillCRM.Business.Dtos
{
    public class UpdateProduct
    {
        public int Id { get; set; }

        public String? ProductName { get; set; }

        public String? SerialNumber { get; set; }

        public decimal Price { get; set; }

        public String? Description { get; set; }
    }
}
