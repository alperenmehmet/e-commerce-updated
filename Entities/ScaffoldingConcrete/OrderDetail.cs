using Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.ScaffoldingConcrete
{
    public partial class OrderDetail : IEntity
    {
        public int OrderDetailId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int? ProductId { get; set; }
        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
