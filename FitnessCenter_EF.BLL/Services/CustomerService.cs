using AutoMapper;
using FitnessCenter_EF.BLL.Contracts;
using FitnessCenter_EF.BLL.DTOs.Customer;
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
    public class CustomerService : ICustomerService
    {
        public CustomerService(IUnitOfWork unitOfOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfOfWork;
            Mapper = mapper;
        }
        private IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public async Task<Guid> CreateAsync(CreateCustomerDTO entity)
        {
            Customer Customer = Mapper.Map<Customer>(entity);
            var id = await UnitOfWork.Customers.CreateAsync(Customer);
            await UnitOfWork.SaveChangesAsync();
            return id;
        }
        public async Task DeleteAsync(Guid id)
        {
            await UnitOfWork.Customers.DeleteAsync(id);
            await UnitOfWork.SaveChangesAsync();
        }
        public async Task<PagedList<ExpandoObject>> GetAllAsync(CustomerParameters parameters)
        {
            var list = await UnitOfWork.Customers.GetAllAsync(parameters);
            return list;
        }
        public async Task<CustomerDTO?> GetAsync(Guid id)
        {
            Customer? Customer = await UnitOfWork.Customers.GetByIdAsync(id);
            CustomerDTO? CustomerDTO = Mapper.Map<CustomerDTO?>(Customer);
            return CustomerDTO;
        }
        public async Task UpdateAsync(UpdateCustomerDTO entity)
        {
            Customer Customer = Mapper.Map<Customer>(entity);
            await UnitOfWork.Customers.UpdateAsync(Customer);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
