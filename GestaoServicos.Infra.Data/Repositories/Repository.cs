using GestaoServicos.Domain.Repository;
using GestaoServicos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestaoServicos.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly GestaoServicosDbContext _context;
        public Repository(GestaoServicosDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> expression, string include = null)
        {
            if (!string.IsNullOrWhiteSpace(include))
            {
                return _context.Set<T>().Where(expression).Include(include).AsQueryable();
            }

            return _context.Set<T>().Where(expression).AsQueryable();
        }

        public IQueryable<T> GetAll(string include = null)
        {
            if (!string.IsNullOrWhiteSpace(include))
            {
                return _context.Set<T>().Include(include).AsQueryable();
            }

            return _context.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
