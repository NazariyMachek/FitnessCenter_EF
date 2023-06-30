using AutoMapper;
using FitnessCenter_EF.BLL.Contracts;
using FitnessCenter_EF.BLL.DTOs.Subscription;
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
    public class SubscriptionService : ISubscriptionService
    {
        public SubscriptionService(IUnitOfWork unitOfOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfOfWork;
            Mapper = mapper;
        }
        private IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public async Task<Guid> CreateAsync(CreateSubscriptionDTO entity)
        {
            Subscription Subscription = Mapper.Map<Subscription>(entity);
            var id = await UnitOfWork.Subscriptions.CreateAsync(Subscription);
            await UnitOfWork.SaveChangesAsync();
            return id;
        }
        public async Task DeleteAsync(Guid id)
        {
            await UnitOfWork.Subscriptions.DeleteAsync(id);
            await UnitOfWork.SaveChangesAsync();
        }
        public async Task<PagedList<ExpandoObject>> GetAllAsync(SubscriptionParameters parameters)
        {
            var list = await UnitOfWork.Subscriptions.GetAllAsync(parameters);
            return list;
        }
        public async Task<SubscriptionDTO?> GetAsync(Guid id)
        {
            Subscription? Subscription = await UnitOfWork.Subscriptions.GetByIdAsync(id);
            SubscriptionDTO? SubscriptionDTO = Mapper.Map<SubscriptionDTO?>(Subscription);
            return SubscriptionDTO;
        }
        public async Task UpdateAsync(UpdateSubscriptionDTO entity)
        {
            Subscription Subscription = Mapper.Map<Subscription>(entity);
            await UnitOfWork.Subscriptions.UpdateAsync(Subscription);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
