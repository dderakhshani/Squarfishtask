using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Squarfish2.DataAccess.Infrastructure
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
        Task<int> SaveChangesAsync();
    }


    public interface IRepository<T> : IRepository where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        Task<T> FindById(int Id);

        Task<int> GetCountAsync(Expression<Func<T, bool>> predicate);

    }
}
