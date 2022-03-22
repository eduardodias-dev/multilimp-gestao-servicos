using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestaoServicos.Domain.Repository
{
    public interface IRepository<T>
    {
        Task<T> Get(int id);
        IQueryable<T> GetAll(string include = null);
        IQueryable<T> Get(Expression<Func<T, bool>> expression, string include = null);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        void Commit(T entity);
    }
}
