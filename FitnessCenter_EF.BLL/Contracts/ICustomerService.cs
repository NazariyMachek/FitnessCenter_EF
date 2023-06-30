using FitnessCenter_EF.BLL.DTOs.Customer;
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
    public interface ICustomerService
    {
        Task<Guid> CreateAsync(CreateCustomerDTO entity);
        Task<CustomerDTO?> GetAsync(Guid id);
        Task<PagedList<ExpandoObject>> GetAllAsync(CustomerParameters parameters);
        Task UpdateAsync(UpdateCustomerDTO entity);
        Task DeleteAsync(Guid id);
    }
}
