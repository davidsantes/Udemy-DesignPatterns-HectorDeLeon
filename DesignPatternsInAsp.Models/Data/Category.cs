﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DesignPatternsInAsp.Models.Data
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public string CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
