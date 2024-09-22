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
        public void add(TEntity entity)
        {
            using (TContext context=new TContext())
            {
                var addeEntity=context.Entry(entity);
                addeEntity.State = EntityState.Added;
                context.SaveChanges();

            }
            
        }

        public void delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity=context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public void update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity=context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
        //*****************************

        //Read Operations

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context=new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context=new TContext())
            {
                return filter==null ?context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();

            }
        }

        
    }
}
