using ShopsRUS.Core.DataAccess;
using ShopsRUS.Core.Entity;
using ShopsRUS.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUS.DataAccess.Abstract
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        Task<BaseResponse<dynamic>> GetInvoice(string invoiceNumber);
    }
}
