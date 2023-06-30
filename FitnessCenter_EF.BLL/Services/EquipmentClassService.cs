using AutoMapper;
using FitnessCenter_EF.BLL.Contracts;
using FitnessCenter_EF.BLL.DTOs.EquipmentClass;
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
    public class EquipmentClassService : IEquipmentClassService
    {
        public EquipmentClassService(IUnitOfWork unitOfOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfOfWork;
            Mapper = mapper;
        }
        private IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public async Task<(Guid, Guid)> CreateAsync(CreateEquipmentClassDTO entity)
        {
            EquipmentClass EquipmentClass = Mapper.Map<EquipmentClass>(entity);
            var id = await UnitOfWork.EquipmentClass.CreateAsync(EquipmentClass);
            await UnitOfWork.SaveChangesAsync();
            return id;
        }
        public async Task DeleteAsync(Guid EquipmentId, Guid ClassId)
        {
            await UnitOfWork.EquipmentClass.DeleteAsync(EquipmentId, ClassId);
            await UnitOfWork.SaveChangesAsync();
        }
        public async Task<PagedList<ExpandoObject>> GetAllAsync(EquipmentClassParameters parameters)
        {
            var list = await UnitOfWork.EquipmentClass.GetAllAsync(parameters);
            return list;
        }
        public async Task<EquipmentClassDTO?> GetAsync(Guid EquipmentId, Guid ClassId)
        {
            EquipmentClass? EquipmentClass = await UnitOfWork.EquipmentClass.GetByIdAsync(EquipmentId, ClassId);
            EquipmentClassDTO? EquipmentClassDTO = Mapper.Map<EquipmentClassDTO?>(EquipmentClass);
            return EquipmentClassDTO;
        }
        public async Task UpdateAsync(UpdateEquipmentClassDTO entity)
        {
            EquipmentClass EquipmentClass = Mapper.Map<EquipmentClass>(entity);
            await UnitOfWork.EquipmentClass.UpdateAsync(EquipmentClass);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
