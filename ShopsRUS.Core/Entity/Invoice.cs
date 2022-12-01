using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUS.Core.Entity
{
    public class Invoice:BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string InvoiceNumber { get; set; }
        public double Discount { get; set; }
        public double Amount { get; set; }
        public double NetPrice { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
