using ShopsRUS.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUS.Business.Abstract
{
    public interface IDiscountService
    {
        Task<BaseResponse<DiscountResponse>> CalculateDiscount(DiscountRequest request);
    }
}
