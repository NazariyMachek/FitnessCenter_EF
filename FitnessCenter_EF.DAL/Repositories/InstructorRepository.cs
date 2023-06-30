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
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(DataContext dataContext, ISortHelper<Instructor> sortHelper, IDataShaper<Instructor> dataShaper)
            : base(dataContext, sortHelper, dataShaper) { }

        public override async Task<Guid> CreateAsync(Instructor entity)
        {
            await entities.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.InstructorId;
        }
    }
}
