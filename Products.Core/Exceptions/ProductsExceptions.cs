using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Core.Exceptions
{
    public class ProductsExceptions : Exception
    {
        public ProductsExceptions()
        {

        }
        public ProductsExceptions(string message) : base(message)
        {

        }
    }
}
