using FitnessCenter_EF.DAL.Contracts;
using FitnessCenter_EF.DAL.Data;
using FitnessCenter_EF.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.DAL.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext dataContext, ISortHelper<Customer> sortHelper, IDataShaper<Customer> dataShaper)
            : base(dataContext, sortHelper, dataShaper) { }

        public override async Task<Guid> CreateAsync(Customer entity)
        {
            await entities.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.CustomerId;
        }
    }
}
