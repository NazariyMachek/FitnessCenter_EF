using FitnessCenter_EF.BLL.DTOs.Attendance;
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
    public interface IAttendanceService
    {
        Task<Guid> CreateAsync(CreateAttendanceDTO entity);
        Task<AttendanceDTO?> GetAsync(Guid id);
        Task<PagedList<ExpandoObject>> GetAllAsync(AttendanceParameters parameters);
        Task UpdateAsync(UpdateAttendanceDTO entity);
        Task DeleteAsync(Guid id);
    }
}
