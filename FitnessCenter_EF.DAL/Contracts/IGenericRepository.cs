using FitnessCenter_EF.DAL.Paging;
using FitnessCenter_EF.DAL.Paging.Parameters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.DAL.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<Guid> CreateAsync(TEntity entity);
        Task<PagedList<ExpandoObject>> GetAllAsync(BaseParameters parameters);
        Task<TEntity?> GetByIdAsync(Guid id);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
    }
}
