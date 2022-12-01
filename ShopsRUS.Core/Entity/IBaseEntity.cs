using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUS.Core.Entity
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTime? CreateDate { get; set; }
        DateTime? UpdateDate { get; set; }
        bool IsActive { get; set; }

    }
}
