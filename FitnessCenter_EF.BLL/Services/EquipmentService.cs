using AutoMapper;
using FitnessCenter_EF.BLL.Contracts;
using FitnessCenter_EF.BLL.DTOs.Equipment;
using FitnessCenter_EF.DAL.Contracts;
using FitnessCenter_EF.DAL.Models;
using FitnessCenter_EF.DAL.Paging;
using FitnessCenter_EF.DAL.Paging.Parameters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.BLL.Services
{
    public class EquipmentService : IEquipmentService
    {
        public EquipmentService(IUnitOfWork unitOfOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfOfWork;
            Mapper = mapper;
        }
        private IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public async Task<Guid> CreateAsync(CreateEquipmentDTO entity)
        {
            Equipment Equipment = Mapper.Map<Equipment>(entity);
            var id = await UnitOfWork.Equipment.CreateAsync(Equipment);
            await UnitOfWork.SaveChangesAsync();
            return id;
        }
        public async Task DeleteAsync(Guid id)
        {
            await UnitOfWork.Equipment.DeleteAsync(id);
            await UnitOfWork.SaveChangesAsync();
        }
        public async Task<PagedList<ExpandoObject>> GetAllAsync(EquipmentParameters parameters)
        {
            var list = await UnitOfWork.Equipment.GetAllAsync(parameters);
            return list;
        }
        public async Task<EquipmentDTO?> GetAsync(Guid id)
        {
            Equipment? Equipment = await UnitOfWork.Equipment.GetByIdAsync(id);
            EquipmentDTO? EquipmentDTO = Mapper.Map<EquipmentDTO?>(Equipment);
            return EquipmentDTO;
        }
        public async Task UpdateAsync(UpdateEquipmentDTO entity)
        {
            Equipment Equipment = Mapper.Map<Equipment>(entity);
            await UnitOfWork.Equipment.UpdateAsync(Equipment);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
