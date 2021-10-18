using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Squarfish2.DataAccess.Infrastructure
{
    public interface IUnitOfWork
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class, IBaseEntity;

        Task<int> SaveChangesAsync();

        int SaveChanges();

    }
}
