using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUS.Core.Model
{
    public class DiscountResponse
    {
        public double Amount { get; set; }
        public double Discount { get; set; }
        public double NetPrice { get; set; }
    }
}
