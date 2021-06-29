using Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.ScaffoldingConcrete
{
    public partial class ProductImage : IEntity
    {
        public int ProductImageId { get; set; }
        public string ImagePath { get; set; }
        public DateTime? UploadDate { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
