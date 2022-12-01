using ShopsRUS.Core.DataAccess.Ef;
using ShopsRUS.Core.Entity;
using ShopsRUS.DataAccess.Abstract;
using ShopsRUS.DataAccess.Concrete.Ef.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUS.DataAccess.Concrete.Ef
{
    public class ProductTypeRepository : EfRepository<ProductType>, IProductTypeRepository
    {
        private ShopContext ctx;
        public ProductTypeRepository(ShopContext context) : base(context)
        {
            ctx = context;
        }

    }
}
