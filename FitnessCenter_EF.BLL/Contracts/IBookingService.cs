using FitnessCenter_EF.BLL.DTOs.Booking;
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
    public interface IBookingService
    {
        Task<Guid> CreateAsync(CreateBookingDTO entity);
        Task<BookingDTO?> GetAsync(Guid id);
        Task<PagedList<ExpandoObject>> GetAllAsync(BookingParameters parameters);
        Task UpdateAsync(UpdateBookingDTO entity);
        Task DeleteAsync(Guid id);
    }
}
