using ShopsRUS.Business.Abstract;
using ShopsRUS.Core.Model;
using ShopsRUS.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUS.Business.Concrete
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        public DiscountService(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
        public async Task<BaseResponse<DiscountResponse>> CalculateDiscount(DiscountRequest request)
        {
            return await _discountRepository.CalculateDiscount(request);
        }
    }
}
