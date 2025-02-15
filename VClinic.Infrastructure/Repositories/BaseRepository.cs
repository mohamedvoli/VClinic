using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VClinic.Domain.Repositories;
using VClinic.Infrastructure.Persistence.DbContexts;

namespace VClinic.Infrastructure.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly VClinicDbContext _dbContext;

        public BaseRepository(VClinicDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        //public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        //{
        //    return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        //}

        //public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
        //    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //    string includeString = null,
        //    bool disableTracking = true)
        //{
        //    IQueryable<T> query = _dbContext.Set<T>();
        //    if (disableTracking)
        //        query = query.AsNoTracking();

        //    if (!string.IsNullOrWhiteSpace(includeString))
        //        query = query.Include(includeString);

        //    if (predicate != null)
        //        query = query.Where(predicate);

        //    if (orderBy != null)
        //        return await orderBy(query).ToListAsync();

        //    return await query.ToListAsync();
        //}

        //public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
        //    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //    List<Expression<Func<T, object>>> includes = null,
        //    bool disableTracking = true)
        //{
        //    IQueryable<T> query = _dbContext.Set<T>();
        //    if (disableTracking)
        //        query = query.AsNoTracking();

        //    if (includes != null)
        //        query = includes.Aggregate(query, (current, include) => current.Include(include));

        //    if (predicate != null)
        //        query = query.Where(predicate);

        //    if (orderBy != null)
        //        return await orderBy(query).ToListAsync();

        //    return await query.ToListAsync();
        //}



        //public async Task<IReadOnlyList<T>> GetPagedResponseAsync(int page, int size)
        //{
        //    return await _dbContext.Set<T>()
        //        .Skip((page - 1) * size)
        //        .Take(size)
        //        .AsNoTracking()
        //        .ToListAsync();
        //}
    }
}
