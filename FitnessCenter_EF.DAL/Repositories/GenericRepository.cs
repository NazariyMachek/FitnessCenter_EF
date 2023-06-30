using FitnessCenter_EF.DAL.Contracts;
using FitnessCenter_EF.DAL.Data;
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
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected GenericRepository(DataContext dbContext, ISortHelper<TEntity> sortHelper, IDataShaper<TEntity> dataShaper)
        {
            this.dbContext = dbContext;
            this.entities = dbContext.Set<TEntity>();
            _sortHelper = sortHelper;
            _dataShaper = dataShaper;
        }
        protected readonly DataContext dbContext;
        protected readonly DbSet<TEntity> entities;
        protected readonly ISortHelper<TEntity> _sortHelper;
        protected readonly IDataShaper<TEntity> _dataShaper;

        public abstract Task<Guid> CreateAsync(TEntity entity);
        public virtual async Task<PagedList<ExpandoObject>> GetAllAsync(BaseParameters parameters)
        {
            var list = entities.AsNoTracking();
            var newList = _sortHelper.ApplySort(list, parameters.OrderBy);
            var shapedList = _dataShaper.ShapeData(newList, parameters.Fields ?? "").AsQueryable();
            return await Task.Run(() => PagedList<ExpandoObject>
                .ToPagedList(shapedList, parameters.PageNumber, parameters.PageSize));
        }
        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await entities.FindAsync(id);
        }
        public virtual async Task UpdateAsync(TEntity entity)
        {
            entities.Update(entity);
            await dbContext.SaveChangesAsync();
        }
        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception($"{typeof(TEntity).Name} with id: [{id}] was not found");
            }
            await Task.Run(() => entities.Remove(entity));
            await dbContext.SaveChangesAsync();
        }
    }
}
