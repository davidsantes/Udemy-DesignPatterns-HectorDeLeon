﻿using System.Collections.Generic;

#nullable disable

namespace DesignPatterns._4._0._Otros.Repository.Models
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
