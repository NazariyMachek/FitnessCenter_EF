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
    public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(DataContext dataContext, ISortHelper<Attendance> sortHelper, IDataShaper<Attendance> dataShaper)
            : base(dataContext, sortHelper, dataShaper) { }

        public override async Task<Guid> CreateAsync(Attendance entity)
        {
            await entities.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.AttendanceId;
        }
        public override async Task<PagedList<ExpandoObject>> GetAllAsync(BaseParameters parameters)
        {
            var list = dbContext.Attendances
                .AsNoTracking()
                .Include(a => a.Customer)
                .Include(a => a.Class);
            var newList = _sortHelper.ApplySort(list, parameters.OrderBy);
            var shapedList = _dataShaper.ShapeData(newList, parameters.Fields ?? "").AsQueryable();
            return await Task.Run(() => PagedList<ExpandoObject>
                .ToPagedList(shapedList, parameters.PageNumber, parameters.PageSize));
        }
        public override async Task<Attendance?> GetByIdAsync(Guid id)
        {
            var entity = await dbContext.Attendances
                .AsNoTracking()
                .Include(a => a.Customer)
                .Include(a => a.Class)
                .FirstOrDefaultAsync(a => a.AttendanceId == id);
            return entity;
        }
    }
}
