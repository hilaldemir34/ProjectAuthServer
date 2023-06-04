using AuthServer.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Data.Repositories
{
    //coredaki IGenefricRepository yi implemente ediyoruz.
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class//burda yapacağım her şey memory ye yansıyıp bekleyecek.
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
;        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);//asenkronla beraber bloklanmayan threadler yazıyoruz. 
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if(entity!=null)
            {
                _context.Entry(entity).State = EntityState.Detached;//eğer entity null değilse bu entity memory de tutulmasın
            }
            return entity;
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);//entitynin state ini deleted olarak işaretliyor.
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}
