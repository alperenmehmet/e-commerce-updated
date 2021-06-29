using Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.ScaffoldingConcrete
{
    public partial class Category : IEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
