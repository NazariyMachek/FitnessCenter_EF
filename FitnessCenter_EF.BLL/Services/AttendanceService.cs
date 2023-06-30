using AutoMapper;
using FitnessCenter_EF.BLL.Contracts;
using FitnessCenter_EF.BLL.DTOs.Attendance;
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
    public class AttendanceService : IAttendanceService
    {
        public AttendanceService(IUnitOfWork unitOfOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfOfWork;
            Mapper = mapper;
        }
        private IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public async Task<Guid> CreateAsync(CreateAttendanceDTO entity)
        {
            Attendance attendance = Mapper.Map<Attendance>(entity);
            var id = await UnitOfWork.Attendance.CreateAsync(attendance);
            await UnitOfWork.SaveChangesAsync();
            return id;
        }
        public async Task DeleteAsync(Guid id)
        {
            await UnitOfWork.Attendance.DeleteAsync(id);
            await UnitOfWork.SaveChangesAsync();
        }
        public async Task<PagedList<ExpandoObject>> GetAllAsync(AttendanceParameters parameters)
        {
            var list = await UnitOfWork.Attendance.GetAllAsync(parameters);
            return list;
        }
        public async Task<AttendanceDTO?> GetAsync(Guid id)
        {
            Attendance? attendance = await UnitOfWork.Attendance.GetByIdAsync(id);
            AttendanceDTO? attendanceDTO = Mapper.Map<AttendanceDTO?>(attendance);
            return attendanceDTO;
        }
        public async Task UpdateAsync(UpdateAttendanceDTO entity)
        {
            Attendance attendance = Mapper.Map<Attendance>(entity);
            await UnitOfWork.Attendance.UpdateAsync(attendance);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
