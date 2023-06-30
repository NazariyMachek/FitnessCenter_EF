using FitnessCenter_EF.BLL.DTOs.Class;
using FitnessCenter_EF.DAL.Paging;
using FitnessCenter_EF.DAL.Paging.Parameters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.BLL.Contracts
{
    public interface IClassService
    {
        Task<Guid> CreateAsync(CreateClassDTO entity);
        Task<ClassDTO?> GetAsync(Guid id);
        Task<PagedList<ExpandoObject>> GetAllAsync(ClassParameters parameters);
        Task UpdateAsync(UpdateClassDTO entity);
        Task DeleteAsync(Guid id);
    }
}
