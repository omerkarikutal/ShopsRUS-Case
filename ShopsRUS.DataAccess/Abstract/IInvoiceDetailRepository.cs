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
    public interface IDiscountRepository : IRepository<Discount>
    {
        Task<BaseResponse<DiscountResponse>> CalculateDiscount(DiscountRequest request);
    }
}
