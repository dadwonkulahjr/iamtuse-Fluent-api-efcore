using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace iamtuseFluentApi.Infrastructure.Services.IRepository.Repository
{
    public class GeneralRepository<TEntity> : IGeneralRepository<TEntity> where TEntity : class
    {
        protected internal DbContext _dbContext;
        internal DbSet<TEntity> _dbSetQuery;
        public GeneralRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSetQuery = dbContext.Set<TEntity>();
        }
        public async Task Add(TEntity myEntityToAdd)
        {
            await _dbSetQuery.AddAsync(myEntityToAdd);
        }
        public async Task<TEntity> Get(int id)
        {
            var find = await _dbSetQuery.FindAsync(id);
            if (find != null)
            {
                return find;
            }
            return null;
        }
        public async Task<TEntity> Get(TEntity myEntity)
        {
            return await _dbSetQuery.FindAsync(myEntity);
        }
        public async Task<IEnumerable<TEntity>> GetAllMatchingEntityType(Expression<Func<TEntity, bool>> filterEntityPass = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderEntityPass = null, string navigationProperty = null)
        {
            IQueryable<TEntity> entitiesQuery = _dbSetQuery;

            if (filterEntityPass != null)
            {
                entitiesQuery = entitiesQuery.Where(filterEntityPass);
            }

            if (navigationProperty != null)
            {
                foreach (var property in navigationProperty.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    entitiesQuery = entitiesQuery.Include(property);
                }
            }

            if (orderEntityPass != null)
            {
                return await orderEntityPass(entitiesQuery).ToListAsync();
            }

            return await entitiesQuery.ToListAsync();
        }
        public async Task<TEntity> GetFirstOrDefaultMatchingEntityType(Expression<Func<TEntity, bool>> filterEntityPass = null, string navigationProperty = null)
        {
            IQueryable<TEntity> entitiesQuery = _dbSetQuery;

            if (filterEntityPass != null)
            {
                entitiesQuery = entitiesQuery.Where(filterEntityPass);
            }

            if (navigationProperty != null)
            {
                foreach (var property in navigationProperty.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    entitiesQuery = entitiesQuery.Include(property);
                }
            }

            return await entitiesQuery.FirstOrDefaultAsync();
        }
    }
}
