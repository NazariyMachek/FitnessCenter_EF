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
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(DataContext dataContext, ISortHelper<Booking> sortHelper, IDataShaper<Booking> dataShaper)
            : base(dataContext, sortHelper, dataShaper) { }

        public override async Task<Guid> CreateAsync(Booking entity)
        {
            await entities.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.BookingId;
        }
        public override async Task<PagedList<ExpandoObject>> GetAllAsync(BaseParameters parameters)
        {
            var list = dbContext.Bookings
                .AsNoTracking()
                .Include(b => b.Customer)
                .Include(b => b.Class);
            var newList = _sortHelper.ApplySort(list, parameters.OrderBy);
            var shapedList = _dataShaper.ShapeData(newList, parameters.Fields ?? "").AsQueryable();
            return await Task.Run(() => PagedList<ExpandoObject>
                .ToPagedList(shapedList, parameters.PageNumber, parameters.PageSize));
        }
        public override async Task<Booking?> GetByIdAsync(Guid id)
        {
            var entity = await dbContext.Bookings
                .AsNoTracking()
                .Include(b => b.Customer)
                .Include(b => b.Class)
                .FirstOrDefaultAsync(b => b.BookingId == id);
            return entity;
        }
    }
}
