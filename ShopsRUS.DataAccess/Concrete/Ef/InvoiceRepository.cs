using Microsoft.EntityFrameworkCore;
using ShopsRUS.Core.DataAccess.Ef;
using ShopsRUS.Core.Entity;
using ShopsRUS.Core.Model;
using ShopsRUS.DataAccess.Abstract;
using ShopsRUS.DataAccess.Concrete.Ef.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUS.DataAccess.Concrete.Ef
{
    public class InvoiceRepository : EfRepository<Invoice>, IInvoiceRepository
    {
        private ShopContext ctx;
        public InvoiceRepository(ShopContext context) : base(context)
        {
            ctx = context;
        }

        public async Task<BaseResponse<dynamic>> GetInvoice(string invoiceNumber)
        {
            try
            {
                var invoiceDetail = ctx.Invoices.Where(s => s.InvoiceNumber == invoiceNumber)
                    .AsNoTracking()
                    .Include(s => s.User)
                    .Include(s => s.InvoiceDetails)
                    .ThenInclude(x => x.Product)
                    .ThenInclude(b => b.ProductType)
                    .Select(z => new
                    {
                        InvoiceNumber = invoiceNumber,
                        UserName = $"{z.User.Name} {z.User.Surname}",
                        TotalPrice = z.NetPrice,
                        Amount = z.Amount,
                        Discount = z.Discount,
                        Products = z.InvoiceDetails.Select(a => new
                        {
                            ProductName = a.Product.Name,
                            Price = a.Product.Price,
                            ProductType = a.Product.ProductType.Name
                        })

                    }).FirstOrDefaultAsync();

                return new BaseResponse<dynamic>().Success(invoiceDetail.Result);
            }
            catch (Exception e)
            {
                return new BaseResponse<dynamic>().Fail(e.Message);
            }

        }
    }
}
