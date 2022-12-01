using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUS.Core.Entity
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
