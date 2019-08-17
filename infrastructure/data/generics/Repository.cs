using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using domain.generics;
using Microsoft.EntityFrameworkCore;

namespace infraestructure.data.generics
{
    public class Repository<TEntity> where TEntity : Entity
    {
        public DbSet<TEntity> Set { get; set; }
        public DbContext Context { get; set; }

        public Repository(DbContext context) {
            this.Context = context;
            Set = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetEntities(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
        )
        {
            IQueryable<TEntity> query = Set;
            if (filter != null) query.Where(filter);
            if (orderBy != null) orderBy(query).ToList();
            return query.ToList();
        }

        public virtual TEntity GetEntity(object key)
        {
            return GetEntities(e => e.Key.Equals(key)).FirstOrDefault();
        }

        public virtual TEntity DeleteEntity(object key)
        {
            TEntity entityToDelete = GetEntity(key);
            Set.Remove(entityToDelete);
            return entityToDelete;
        }

        public void DeleteEntities(Expression<Func<TEntity, bool>> filter)
        {
            Set.RemoveRange(GetEntities(filter));
        }

        public void DeleteEntity(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Set.Attach(entity);
            }
            Set.Remove(entity);
        }

        public virtual void UpdateEntity(TEntity entity)
        {
            Set.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void UpdateEntities(
            Expression<Func<TEntity, bool>> filter,
            Action<TEntity> action
        )
        {
            IQueryable<TEntity> query = Set;
            query.Where(filter).ToList().ForEach(action);
            Set.UpdateRange(query);
        }

        public virtual void InsertEntity(TEntity entity)
        {
            Set.Add(entity);
        }

        public virtual void InsertEntities(IEnumerable<TEntity> entities)
        {
            Set.AddRange(entities);
        }

    }
}