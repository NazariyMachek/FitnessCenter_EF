using FitnessCenter_EF.BLL.DTOs.Equipment;
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
    public interface IEquipmentService
    {
        Task<Guid> CreateAsync(CreateEquipmentDTO entity);
        Task<EquipmentDTO?> GetAsync(Guid id);
        Task<PagedList<ExpandoObject>> GetAllAsync(EquipmentParameters parameters);
        Task UpdateAsync(UpdateEquipmentDTO entity);
        Task DeleteAsync(Guid id);
    }
}
