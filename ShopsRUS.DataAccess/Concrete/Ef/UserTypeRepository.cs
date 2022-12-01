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
    public class UserTypeRepository : EfRepository<UserType>, IUserTypeRepository
    {
        private ShopContext ctx;
        public UserTypeRepository(ShopContext context) : base(context)
        {
            ctx = context;
        }

    }
}
