using AutoMapper;
using FitnessCenter_EF.BLL.Contracts;
using FitnessCenter_EF.BLL.DTOs.Class;
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
    public class ClassService : IClassService
    {
        public ClassService(IUnitOfWork unitOfOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfOfWork;
            Mapper = mapper;
        }
        private IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public async Task<Guid> CreateAsync(CreateClassDTO entity)
        {
            Class Class = Mapper.Map<Class>(entity);
            var id = await UnitOfWork.Classes.CreateAsync(Class);
            await UnitOfWork.SaveChangesAsync();
            return id;
        }
        public async Task DeleteAsync(Guid id)
        {
            await UnitOfWork.Classes.DeleteAsync(id);
            await UnitOfWork.SaveChangesAsync();
        }
        public async Task<PagedList<ExpandoObject>> GetAllAsync(ClassParameters parameters)
        {
            var list = await UnitOfWork.Classes.GetAllAsync(parameters);
            return list;
        }
        public async Task<ClassDTO?> GetAsync(Guid id)
        {
            Class? Class = await UnitOfWork.Classes.GetByIdAsync(id);
            ClassDTO? ClassDTO = Mapper.Map<ClassDTO?>(Class);
            return ClassDTO;
        }
        public async Task UpdateAsync(UpdateClassDTO entity)
        {
            Class Class = Mapper.Map<Class>(entity);
            await UnitOfWork.Classes.UpdateAsync(Class);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
