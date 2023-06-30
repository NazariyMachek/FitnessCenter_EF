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
    public class SubscriptionRepository : GenericRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(DataContext dataContext, ISortHelper<Subscription> sortHelper, IDataShaper<Subscription> dataShaper)
            : base(dataContext, sortHelper, dataShaper) { }

        public override async Task<Guid> CreateAsync(Subscription entity)
        {
            await entities.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.SubscriptionId;
        }
        public override async Task<PagedList<ExpandoObject>> GetAllAsync(BaseParameters parameters)
        {
            var param = (SubscriptionParameters)parameters;
            var list = dbContext.Subscriptions
                .AsNoTracking()
                .Include(s => s.Customer)
                .Where(s => s.Price >= param.MinPrice && s.Price <= param.MaxPrice);
            SearchByUserName(ref list, param.CustomerName);
            var newList = _sortHelper.ApplySort(list, parameters.OrderBy);
            var shapedList = _dataShaper.ShapeData(newList, parameters.Fields ?? "").AsQueryable();
            return await Task.Run(() => PagedList<ExpandoObject>
                .ToPagedList(shapedList, parameters.PageNumber, parameters.PageSize));
        }
        public override async Task<Subscription?> GetByIdAsync(Guid id)
        {
            var entity = await dbContext.Subscriptions
                .AsNoTracking()
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(s => s.SubscriptionId == id);
            return entity;
        }

        private static void SearchByUserName(ref IQueryable<Subscription> entities, string? customerName)
        {
            if (!entities.Any() || string.IsNullOrWhiteSpace(customerName)) return;

            entities = entities
                .Where(s => (s.Customer.FirstName + " " + s.Customer.LastName).ToLower().Contains(customerName.Trim().ToLower()));
        }
    }
}
