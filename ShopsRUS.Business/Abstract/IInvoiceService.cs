using ShopsRUS.Core.Entity;
using ShopsRUS.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUS.Business.Abstract
{
    public interface IInvoiceService
    {
        Task<BaseResponse<CreateInvoiceResponse>> CreateInvoice(InvoiceRequest request);
        Task<BaseResponse<dynamic>> GetInvoice(string invoiceNumber);
    }
}
