using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.ScaffoldingConcrete
{
    public partial class Customer : IEntity
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerAddress { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
