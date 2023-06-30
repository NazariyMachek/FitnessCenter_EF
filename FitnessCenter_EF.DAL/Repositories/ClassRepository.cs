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
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        public ClassRepository(DataContext dataContext, ISortHelper<Class> sortHelper, IDataShaper<Class> dataShaper)
            : base(dataContext, sortHelper, dataShaper) { }

        public override async Task<Guid> CreateAsync(Class entity)
        {
            await entities.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.ClassId;
        }
        public override async Task<PagedList<ExpandoObject>> GetAllAsync(BaseParameters parameters)
        {
            var list = dbContext.Classes
                .AsNoTracking()
                .Include(c => c.Instructor);
            var newList = _sortHelper.ApplySort(list, parameters.OrderBy);
            var shapedList = _dataShaper.ShapeData(newList, parameters.Fields ?? "").AsQueryable();
            return await Task.Run(() => PagedList<ExpandoObject>
                .ToPagedList(shapedList, parameters.PageNumber, parameters.PageSize));
        }
        public override async Task<Class?> GetByIdAsync(Guid id)
        {
            var entity = await dbContext.Classes
                .AsNoTracking()
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(c => c.ClassId == id);
            return entity;
        }
    }
}
