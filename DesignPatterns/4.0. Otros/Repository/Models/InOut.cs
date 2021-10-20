using System;
using System.Collections.Generic;

#nullable disable

namespace DesignPatterns._4._0._Otros.Repository.Models
{
    public partial class InOut
    {
        public string InOutId { get; set; }
        public DateTime InOutDate { get; set; }
        public int Quantity { get; set; }
        public bool IsInput { get; set; }
        public string StorageId { get; set; }

        public virtual Storage Storage { get; set; }
    }
}
