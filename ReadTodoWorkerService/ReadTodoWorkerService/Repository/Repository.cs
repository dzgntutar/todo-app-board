using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReadTodoWorkerService.Data;
using ReadTodoWorkerService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReadTodoWorkerService.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        IServiceProvider _serviceProvider;
        public Repository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                return filter == null
                ? _context.Set<TEntity>().ToList()
                : _context.Set<TEntity>().Where(filter).ToList();
            }

        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                return _context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public TEntity Add(TEntity entity)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var addedEntity = _context.Entry(entity);
                addedEntity.State = EntityState.Added;
                _context.SaveChanges();
                return entity;
            }
        }

        public TEntity Update(TEntity entity)
        {
            //var updatedEntity = _context.Entry(entity);
            //updatedEntity.State = EntityState.Modified;
            //_context.SaveChanges();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            //var deletedEntity = _context.Entry(entity);
            //deletedEntity.State = EntityState.Deleted;
            //_context.SaveChanges();
        }
    }
}

