using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Core.QueryFilters
{
    public class ProductQueryFilter
    {
        public string? description { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }
}
