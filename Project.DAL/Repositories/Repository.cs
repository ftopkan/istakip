using Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories
{
    public class Repository<TEntity> where TEntity : class
    {

        internal AppDbContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(AppDbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<TEntity>();
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params string[] includedProps)
        {
            IQueryable<TEntity> entities = dbSet;

            entities = filter != null ? entities.Where(filter) : entities;

            entities = orderBy != null ? orderBy(entities) : entities;

            foreach (var prop in includedProps)
                entities = entities.Include(prop);

            return entities.ToList();
        }

        public TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
                dbSet.Attach(entity);

            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            var deleted = dbSet.Find(id);
            dbSet.Remove(deleted);
        }
    }
}
