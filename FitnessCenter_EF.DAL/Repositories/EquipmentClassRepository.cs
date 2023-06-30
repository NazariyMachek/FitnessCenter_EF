using FitnessCenter_EF.DAL.Contracts;
using FitnessCenter_EF.DAL.Data;
using FitnessCenter_EF.DAL.Helpers;
using FitnessCenter_EF.DAL.Models;
using FitnessCenter_EF.DAL.Paging;
using FitnessCenter_EF.DAL.Paging.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.DAL.Repositories
{
    public class EquipmentClassRepository : IEquipmentClassRepository
    {
        public EquipmentClassRepository(DataContext dbContext, ISortHelper<EquipmentClass> sortHelper, IDataShaper<EquipmentClass> dataShaper)
        {
            _sortHelper = sortHelper;
            _dataShaper = dataShaper;
            this.dbContext = dbContext;
            this.entities = dbContext.Set<EquipmentClass>();
        }
        private readonly DataContext dbContext;
        private readonly DbSet<EquipmentClass> entities;
        private readonly ISortHelper<EquipmentClass> _sortHelper;
        private readonly IDataShaper<EquipmentClass> _dataShaper;

        public async Task<(Guid, Guid)> CreateAsync(EquipmentClass entity)
        {
            await entities.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return (entity.EquipmentId, entity.ClassId);
        }
        public async Task<PagedList<ExpandoObject>> GetAllAsync(EquipmentClassParameters parameters)
        {
            var list = entities
                .AsNoTracking()
                .Include(ec => ec.Equipment)
                .Include(ec => ec.Class);
            var newList = _sortHelper.ApplySort(list, parameters.OrderBy);
            var shapedList = _dataShaper.ShapeData(newList, parameters.Fields ?? "").AsQueryable();
            return await Task.Run(() => PagedList<ExpandoObject>
                .ToPagedList(shapedList, parameters.PageNumber, parameters.PageSize));
        }
        public async Task<EquipmentClass?> GetByIdAsync(Guid EquipmentId, Guid ClassId)
        {
            return await entities
                .AsNoTracking()
                .FirstOrDefaultAsync(ec => ec.EquipmentId == EquipmentId && ec.ClassId == ClassId);
        }
        public async Task UpdateAsync(EquipmentClass entity)
        {
            await Task.Run(() => entities.Update(entity));
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid EquipmentId, Guid ClassId)
        {
            var entity = await GetByIdAsync(EquipmentId, ClassId);
            if (entity == null)
            {
                throw new Exception($"{typeof(EquipmentClass).Name} with id: [{EquipmentId} : {ClassId}] was not found");
            }
            await Task.Run(() => entities.Remove(entity));
            await dbContext.SaveChangesAsync();
        }
    }
}
