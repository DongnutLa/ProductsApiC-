using System;
using System.Collections.Generic;

namespace Products.Core.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public bool? Active { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
