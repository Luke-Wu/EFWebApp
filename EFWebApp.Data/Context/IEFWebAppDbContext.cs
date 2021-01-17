using EFWebApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWebApp.Data.Context
{
    public interface IEFWebAppDbContext : IDisposable
    {
        void SetAsAdded<TEntity>(TEntity entity) where TEntity : Base;

        void SetAsModified<TEntity>(TEntity entity) where TEntity : Base;

        void SetAsDeleted<TEntity>(TEntity entity) where TEntity : Base;

        IDbSet<TEntity> Set<TEntity>() where TEntity : Base;

        Task<int> SaveChangeAsync(int userId);

        Task<int> CommitAsync();





    }
}
