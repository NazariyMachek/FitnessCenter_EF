using FitnessCenter_EF.BLL.DTOs.EquipmentClass;
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
    public interface IEquipmentClassService
    {
        Task<(Guid, Guid)> CreateAsync(CreateEquipmentClassDTO entity);
        Task<EquipmentClassDTO?> GetAsync(Guid EquipmentId, Guid ClassId);
        Task<PagedList<ExpandoObject>> GetAllAsync(EquipmentClassParameters parameters);
        Task UpdateAsync(UpdateEquipmentClassDTO entity);
        Task DeleteAsync(Guid EquipmentId, Guid ClassId);
    }
}
