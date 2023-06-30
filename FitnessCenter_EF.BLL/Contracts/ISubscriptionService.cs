using FitnessCenter_EF.BLL.DTOs.Subscription;
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
    public interface ISubscriptionService
    {
        Task<Guid> CreateAsync(CreateSubscriptionDTO entity);
        Task<SubscriptionDTO?> GetAsync(Guid id);
        Task<PagedList<ExpandoObject>> GetAllAsync(SubscriptionParameters parameters);
        Task UpdateAsync(UpdateSubscriptionDTO entity);
        Task DeleteAsync(Guid id);
    }
}
