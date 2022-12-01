using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUS.Core.Entity
{
    public class Discount : BaseEntity
    {
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }
        public double DiscountRate { get; set; }
    }
}
