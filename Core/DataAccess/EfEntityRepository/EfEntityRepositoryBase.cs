using Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EfEntityRepository
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext :DbContext, new()
    {

        //CUD Operations
        public async Task Add(TEntity entity)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    var addeEntity = context.Entry(entity);
                    addeEntity.State = EntityState.Added;
                    await context.SaveChangesAsync();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public async Task Delete(TEntity entity)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    var deletedEntity = context.Entry(entity);
                    deletedEntity.State = EntityState.Deleted;
                    await context.SaveChangesAsync();

                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity=context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();

            }
        }
        //*****************************

        //Read Operations

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context=new TContext())
            {
                return  await context.Set<TEntity>().SingleOrDefaultAsync(filter);

            }
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context=new TContext())
            {
                return filter==null 
                    ? await context.Set<TEntity>().ToListAsync() 
                    : await context.Set<TEntity>().Where(filter).ToListAsync();

            }
        }

        
    }
}
