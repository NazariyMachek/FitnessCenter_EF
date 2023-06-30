using AutoMapper;
using FitnessCenter_EF.BLL.Contracts;
using FitnessCenter_EF.BLL.DTOs.Instructor;
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
    public class InstructorService : IInstructorService
    {
        public InstructorService(IUnitOfWork unitOfOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfOfWork;
            Mapper = mapper;
        }
        private IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public async Task<Guid> CreateAsync(CreateInstructorDTO entity)
        {
            Instructor Instructor = Mapper.Map<Instructor>(entity);
            var id = await UnitOfWork.Instructors.CreateAsync(Instructor);
            await UnitOfWork.SaveChangesAsync();
            return id;
        }
        public async Task DeleteAsync(Guid id)
        {
            await UnitOfWork.Instructors.DeleteAsync(id);
            await UnitOfWork.SaveChangesAsync();
        }
        public async Task<PagedList<ExpandoObject>> GetAllAsync(InstructorParameters parameters)
        {
            var list = await UnitOfWork.Instructors.GetAllAsync(parameters);
            return list;
        }
        public async Task<InstructorDTO?> GetAsync(Guid id)
        {
            Instructor? Instructor = await UnitOfWork.Instructors.GetByIdAsync(id);
            InstructorDTO? InstructorDTO = Mapper.Map<InstructorDTO?>(Instructor);
            return InstructorDTO;
        }
        public async Task UpdateAsync(UpdateInstructorDTO entity)
        {
            Instructor Instructor = Mapper.Map<Instructor>(entity);
            await UnitOfWork.Instructors.UpdateAsync(Instructor);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
