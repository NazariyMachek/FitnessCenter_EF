using AutoMapper;
using FitnessCenter_EF.BLL.Contracts;
using FitnessCenter_EF.BLL.DTOs.Booking;
using FitnessCenter_EF.DAL.Contracts;
using FitnessCenter_EF.DAL.Models;
using FitnessCenter_EF.DAL.Paging;
using FitnessCenter_EF.DAL.Paging.Parameters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.BLL.Services
{
    public class BookingService : IBookingService
    {
        public BookingService(IUnitOfWork unitOfOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfOfWork;
            Mapper = mapper;
        }
        private IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public async Task<Guid> CreateAsync(CreateBookingDTO entity)
        {
            Booking booking = Mapper.Map<Booking>(entity);
            var id = await UnitOfWork.Bookings.CreateAsync(booking);
            await UnitOfWork.SaveChangesAsync();
            return id;
        }
        public async Task DeleteAsync(Guid id)
        {
            await UnitOfWork.Bookings.DeleteAsync(id);
            await UnitOfWork.SaveChangesAsync();
        }
        public async Task<PagedList<ExpandoObject>> GetAllAsync(BookingParameters parameters)
        {
            var list = await UnitOfWork.Bookings.GetAllAsync(parameters);
            return list;
        }
        public async Task<BookingDTO?> GetAsync(Guid id)
        {
            Booking? booking = await UnitOfWork.Bookings.GetByIdAsync(id);
            BookingDTO? bookingDTO = Mapper.Map<BookingDTO?>(booking);
            return bookingDTO;
        }
        public async Task UpdateAsync(UpdateBookingDTO entity)
        {
            Booking booking = Mapper.Map<Booking>(entity);
            await UnitOfWork.Bookings.UpdateAsync(booking);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
