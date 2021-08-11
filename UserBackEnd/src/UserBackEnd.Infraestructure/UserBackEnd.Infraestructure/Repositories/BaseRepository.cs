using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserBackEnd.Infraestructure.Contracts.Context;
using UserBackEnd.Infraestructure.Contracts.Entities;
using UserBackEnd.Infraestructure.Contracts.Repository;

namespace UserBackEnd.Infraestructure.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T>
        where T : class, IBaseEntity
    {

        protected readonly IDbContext _dbContext;
        protected abstract DbSet<T> DbEntity { get; }

        protected BaseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            await DbEntity.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entityToRemove = await DbEntity.FindAsync(id);
            DbEntity.Remove(entityToRemove);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Expression<Func<T, bool>> where)
        {
            var entities = await DbEntity.Where(where).ToListAsync();
            DbEntity.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> Get(int id)
        {
            return await DbEntity
                .FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await DbEntity.ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            var updatedEntity = DbEntity.Update(entity);
            await _dbContext.SaveChangesAsync();
            return updatedEntity.Entity;
        }

    }
}
