using System;
using System.Collections.Generic;

#nullable disable

namespace DesignPatterns.Estructurales.Repository.Models
{
    public partial class Storage
    {
        public Storage()
        {
            InOuts = new HashSet<InOut>();
        }

        public string StorageId { get; set; }
        public DateTime LastUpdate { get; set; }
        public int PartialQuantity { get; set; }
        public string ProductId { get; set; }
        public string WarehouseId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual ICollection<InOut> InOuts { get; set; }
    }
}
