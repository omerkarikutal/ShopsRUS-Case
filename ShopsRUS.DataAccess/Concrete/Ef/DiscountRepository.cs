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
    public class DiscountRepository : EfRepository<Discount>, IDiscountRepository
    {
        private ShopContext ctx;
        public DiscountRepository(ShopContext context) : base(context)
        {
            ctx = context;
        }
        public async Task<BaseResponse<DiscountResponse>> CalculateDiscount(DiscountRequest request)
        {
            try
            {
                var user = await ctx.Users.FirstOrDefaultAsync(s => s.Id == request.UserId);

                if (user == null) return new BaseResponse<DiscountResponse>().Fail("User Not Found");

                var userDiscount = await ctx.Discounts.FirstOrDefaultAsync(s => s.UserTypeId == user.UserTypeId);

                if (userDiscount == null) return new BaseResponse<DiscountResponse>().Fail("User Discount Not Found");

                var groceryProducts = 0.0;
                var notGroceryProducts = 0.0;
                var totalPrice = 0.0;
                var discount = 0;
                var totalAmount = 0.0;
                foreach (var item in request.Products)
                {
                    var product = await ctx.Products.FirstOrDefaultAsync(s => s.Id == item.Id);

                    if (product != null)
                    {
                        var total = (double)product.Price * item.Quantity;
                        //grocery
                        //enum yapılabilir
                        if (product.ProductTypeId == 3)
                            groceryProducts += total;
                        else
                            notGroceryProducts += total;
                    }
                }
                //totalamount
                totalAmount = groceryProducts + notGroceryProducts;

                notGroceryProducts = notGroceryProducts - (notGroceryProducts * (double)(userDiscount.DiscountRate / 100));

                totalPrice = groceryProducts + notGroceryProducts;


                //100 katta bir indirim uygulanacak
                if (totalPrice > 0)
                {
                    var mod = totalPrice / 100;

                    totalPrice = totalPrice - (5 * Math.Floor(mod));
                }



                var result = new DiscountResponse
                {
                    Amount = totalAmount,
                    NetPrice = totalPrice,
                    Discount = totalAmount - totalPrice
                };

                return new BaseResponse<DiscountResponse>().Success(result);
            }
            catch (Exception e)
            {
                return new BaseResponse<DiscountResponse>().Fail(e.Message);
            }

        }
    }
}
