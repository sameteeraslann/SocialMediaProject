using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TwitterProject.Domain.Entities.Concrete;
using TwitterProject.Domain.Entities.Interface;

namespace TwitterProject.Domain.Repositories.BaseRepo
{
    // Repository: Temel olarak veritabanı sorgulama işlemlerinin bir merkezsen yapılmasını sağlayarak iş katmamına bu işlererin taşınmasını önler bu şekilde sorgu ve kod tekrarını engelleriz.
    public interface IRepository<T> where T : class, IBaseEntity
    {
        Task<List<T>> GetAll();
        Task<List<T>> Get(Expression<Func<T, bool>> expression);

        Task<T> GetById(int id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> expression);
        Task<bool> Any(Expression<Func<T, bool>> expression);

        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);


        Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector,
                                                          Expression<Func<T, bool>> expression = null,
                                                          Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
                                                          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                          bool disableTracking = true);



        Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> selector,
                                                            Expression<Func<T, bool>> expression = null,
                                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
                                                            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                            bool disableTracking = true,
                                                            int pageIndex = 1,
                                                            int pageSize = 3);



    }
}
