using System;
using System.Collections.Generic;

#nullable disable

namespace DesignPatternsInAsp.Models.Data
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            Storages = new HashSet<Storage>();
        }

        public string WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseAddress { get; set; }

        public virtual ICollection<Storage> Storages { get; set; }
    }
}
