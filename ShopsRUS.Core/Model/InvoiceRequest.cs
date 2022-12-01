using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUS.Core.Model
{
    public class InvoiceRequest
    {
        public int UserId { get; set; }
        public List<ProductRequest> Products { get; set; }
    }
    public class ProductRequest
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
