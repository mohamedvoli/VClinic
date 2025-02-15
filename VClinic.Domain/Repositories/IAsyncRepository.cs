using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VClinic.Domain.Repositories
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        //Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        //Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
        //                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //                                string includeString = null,
        //                                bool disableTracking = true);
        //Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
        //                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //                                List<Expression<Func<T, object>>> includes = null,
        //                                bool disableTracking = true);

        //Task<IReadOnlyList<T>> GetPagedResponseAsync(int page, int size);
    }
}
