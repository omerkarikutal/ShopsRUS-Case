using ShopsRUS.Core.Entity;
using ShopsRUS.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUS.Core.DataAccess
{
    public interface IRepository<T> where T : class, IBaseEntity, new()
    {
        Task<BaseResponse<T>> Get(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        Task<BaseResponse<List<T>>> GetList(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        Task<BaseResponse<T>> UpdateAsync(T entity);
        Task<BaseResponse<int>> DeleteAsync(T entity);
        Task<BaseResponse<T>> AddAsync(T entity);
    }
}
