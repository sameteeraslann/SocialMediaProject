using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TwitterProject.Domain.Entities.Interface;
using TwitterProject.Domain.Repositories.BaseRepo;
using TwitterProject.Infrastructure.Context;

namespace TwitterProject.Infrastructure.Repositories.BaseRepo
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IBaseEntity // => "IRepository"'de yazdığımız methodlara burada gövde kazandıracağız ve abstract olarak işaretlediğim "BaseRepository" sınıfını child sınıflarda çağıracağım.
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _table;

        public BaseRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._table = _context.Set<T>();
        }

        public async Task Add(T entity) => await _table.AddAsync(entity);

        public async Task<bool> Any(Expression<Func<T, bool>> expression) => await _table.AnyAsync(expression);

        public void Delete(T entity) => _table.Remove(entity);

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> expression) => await _table.Where(expression).FirstOrDefaultAsync();

        public async Task<List<T>> Get(Expression<Func<T, bool>> expression) => await _table.Where(expression).ToListAsync();

        public async Task<List<T>> GetAll() => await _table.ToListAsync();

        public async Task<T> GetById(int id) => await _table.FindAsync(id);

        public async Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector,// selector => ilk parametre entity tipinde olacak ikinci aldığı parametre ise dönüş tipinde TResult olacaktır.
                                                             Expression<Func<T, bool>> expression = null,// expression => İlk parametredeki verinin bool tipinde dönmesi için bize yardımcı olacak.
                                                             Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,  
                                                             Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                             bool disableTracking = true)
        // IOrderedQueryable => Öğeleri bir anahtara göre sıralanır.
        // IQueryable =>  sorgu alınırken öncelikle filtrelendirme yapılıp sorgu gönderir.
        {
            IQueryable<T> query = _table; //= > Bana gelen tabloyu attım.

            if (disableTracking) query = query.AsNoTracking(); //=> disableTracking varlık üzeründeki değişiklikleri kontrol edip save'e gönderiyor biz filtreme yaptığımızdan filtreleyip gönderiyoruz. Burada disableTracking gerek olmadığı için kapattık.
            if (include != null) query = include(query); // => include edilen nesneleri query'e attık.
            if (expression != null) query = query.Where(expression); // expression ile gelenlere linqto sorgusu yazılması için Where sorgusunu query' e attık.
            if (orderby != null) return await orderby(query).Select(selector).FirstOrDefaultAsync(); // => gelen orderby sorgusu dolu ise bu şart çalışsın
            else return await query.Select(selector).FirstOrDefaultAsync(); //=> null geliyorsa buraya çalışsın

        }

        public async Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> selector, 
                                                         Expression<Func<T, bool>> expression = null,
                                                         Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, 
                                                         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, 
                                                         bool disableTracking = true, int pageIndex = 1, int pageSize = 3)
        {
            IQueryable<T> query = _table;
            if (disableTracking) query = query.AsNoTracking();
            if (include != null) query = include(query);
            if (expression != null) query = query.Where(expression);
            if (orderby != null) return await orderby(query).Select(selector).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            else return await query.Select(selector).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public void Update(T entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
