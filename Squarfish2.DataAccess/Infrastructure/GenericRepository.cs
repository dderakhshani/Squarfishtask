using Microsoft.EntityFrameworkCore;
using Squarfish2.DataAccess.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Squarfish2.DataAccess.Infrastructure
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, IBaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserAccessor _currentUserAccessor;

        public GenericRepository(IUnitOfWork unitOfWork, ICurrentUserAccessor currentUserAccessor)
        {
            this._unitOfWork = unitOfWork;
            this._currentUserAccessor = currentUserAccessor;
        }

        public IUnitOfWork UnitOfWork { get => _unitOfWork; }

        public void Add(TEntity entity)
        {
            if (entity is null) throw new EntityNullException();
            entity.ModifiedAt = DateTime.Now;
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = _currentUserAccessor.GetId();
            entity.IsDeleted = false;

            var entityEntry = _unitOfWork.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            if (entity is null) throw new EntityNullException();
            entity.IsDeleted = true;
            entity.ModifiedAt = DateTime.Now;
            entity.ModifiedBy = _currentUserAccessor.GetId();

            _unitOfWork.Set<TEntity>().Update(entity);
        }

        public async Task<TEntity> FindById(int Id)
        {
            var entity = await _unitOfWork.Set<TEntity>().FindAsync(Id);
            return entity;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _unitOfWork.Set<TEntity>().Where(x=>x.IsDeleted==false);
        }

        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _unitOfWork.Set<TEntity>().CountAsync(predicate);
        }

        public async Task<int> SaveChangesAsync()
        {
            var res = await _unitOfWork.SaveChangesAsync();
            return res;
        }

        public void Update(TEntity entity)
        {
            entity.ModifiedBy = _currentUserAccessor.GetId();
            entity.ModifiedAt = DateTime.Now;

            _unitOfWork.Set<TEntity>().Update(entity);
        }
    }
}
