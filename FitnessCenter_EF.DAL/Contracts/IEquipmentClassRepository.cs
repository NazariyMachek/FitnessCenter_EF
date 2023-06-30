using FitnessCenter_EF.DAL.Models;
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
    public interface IEquipmentClassRepository
    {
        Task<(Guid, Guid)> CreateAsync(EquipmentClass entity);
        Task<PagedList<ExpandoObject>> GetAllAsync(EquipmentClassParameters parameters);
        Task<EquipmentClass?> GetByIdAsync(Guid EquipmentId, Guid ClassId);
        Task UpdateAsync(EquipmentClass entity);
        Task DeleteAsync(Guid EquipmentId, Guid ClassId);
    }
}
