using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUS.Core.Model
{
    public class DiscountRequest
    {
        public int UserId { get; set; }
        public List<ProductRequest> Products { get; set; }
    }
}
