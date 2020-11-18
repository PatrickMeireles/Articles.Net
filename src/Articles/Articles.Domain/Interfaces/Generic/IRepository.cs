using Articles.Entities.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Articles.Domain.Interfaces.Generic
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task<TEntity> Add(TEntity data);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Update(TEntity data);
        Task<Boolean> Delete(int id);
        Task<int> SaveChanges();
    }
}
