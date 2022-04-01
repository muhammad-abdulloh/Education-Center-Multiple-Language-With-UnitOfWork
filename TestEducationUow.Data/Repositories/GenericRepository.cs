using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestEducationCenterUoW.Data.Contexts;
using TestEducationCenterUoW.Data.IRepositories;

namespace TestEducationCenterUoW.Data.Repositories
{
#pragma warning disable
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal EducationCenterDbContext dbContext;
        internal DbSet<T> dbSet;
        private readonly ILogger logger;
        public GenericRepository(EducationCenterDbContext dbContext, ILogger logger)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
            this.logger = logger;
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                var entry = await dbSet.AddAsync(entity);

                return entry.Entity;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                var entity = await dbSet.FirstOrDefaultAsync(expression);

                if (entity is null)
                    return false;

                dbSet.Remove(entity);

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression is null ? dbSet : dbSet.Where(expression);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                var entity = await dbSet.FirstOrDefaultAsync(expression);
                return entity;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var entry = dbSet.Update(entity);

                return entry.Entity;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }
        }
    }
}
