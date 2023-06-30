using FitnessCenter_EF.BLL.DTOs.Instructor;
using FitnessCenter_EF.DAL.Paging;
using FitnessCenter_EF.DAL.Paging.Parameters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.BLL.Contracts
{
    public interface IInstructorService
    {
        Task<Guid> CreateAsync(CreateInstructorDTO entity);
        Task<InstructorDTO?> GetAsync(Guid id);
        Task<PagedList<ExpandoObject>> GetAllAsync(InstructorParameters parameters);
        Task UpdateAsync(UpdateInstructorDTO entity);
        Task DeleteAsync(Guid id);
    }
}
