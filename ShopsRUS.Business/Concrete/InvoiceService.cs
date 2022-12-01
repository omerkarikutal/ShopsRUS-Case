using Mapster;
using ShopsRUS.Business.Abstract;
using ShopsRUS.Core.Entity;
using ShopsRUS.Core.Model;
using ShopsRUS.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUS.Business.Concrete
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;
        public InvoiceService(IInvoiceRepository invoiceRepository,
            IDiscountRepository discountRepository,
            IInvoiceDetailRepository invoiceDetailRepository)
        {
            _invoiceRepository = invoiceRepository;
            _discountRepository = discountRepository;
            _invoiceDetailRepository = invoiceDetailRepository;
        }
        public async Task<BaseResponse<List<Invoice>>> GetAll()
        {
            return await _invoiceRepository.GetList();
        }

        public async Task<BaseResponse<CreateInvoiceResponse>> CreateInvoice(InvoiceRequest request)
        {
            var userDiscount = await _discountRepository.CalculateDiscount(request.Adapt<DiscountRequest>());

            if (!userDiscount.Status) return new BaseResponse<CreateInvoiceResponse>().Fail(userDiscount.ErrorMessage);

            var userDiscountModel = userDiscount.Data;

            var invoice = new Invoice
            {
                CreateDate = DateTime.Now,
                InvoiceNumber = Guid.NewGuid().ToString().Replace("-", ""),
                UserId = request.UserId,
                IsActive = true,
                Amount = userDiscountModel.Amount,
                NetPrice = userDiscountModel.NetPrice,
                Discount = userDiscountModel.Discount
            };

            var invoiceResult = await _invoiceRepository.AddAsync(invoice);

            if (!invoiceResult.Status) return new BaseResponse<CreateInvoiceResponse>().Fail(invoiceResult.ErrorMessage);

            foreach (var item in request.Products)
            {
                var invoiceDetail = new InvoiceDetail
                {
                    InvoiceId = invoiceResult.Data.Id,
                    ProductId = item.Id,
                    Quantity = item.Quantity,
                    CreateDate = DateTime.Now,
                    IsActive = true
                };

                //addrange metodu kullanılmalıdır
                await _invoiceDetailRepository.AddAsync(invoiceDetail);
            }

            return new BaseResponse<CreateInvoiceResponse>().Success(
                new CreateInvoiceResponse
                {
                    InvoiceNumber = invoiceResult.Data.InvoiceNumber
                });
        }

        public async Task<BaseResponse<dynamic>> GetInvoice(string invoiceNumber)
        {
            var result =  await _invoiceRepository.GetInvoice(invoiceNumber);
            return result;
        }
    }
}
