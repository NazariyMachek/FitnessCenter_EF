using AutoMapper;
using FitnessCenter_EF.BLL.DTOs.Subscription;
using FitnessCenter_EF.DAL.Models;

namespace FitnessCenter_EF.API.Mapping
{
    public class SubscriptionProfile : Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<Subscription, SubscriptionDTO>()
                .ForMember(dest => dest.SubscriptionId, opt => opt.MapFrom(src => src.SubscriptionId))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => $"{src.Customer.FirstName} {src.Customer.LastName}"))
                .ForMember(dest => dest.CustomerPhone, opt => opt.MapFrom(src => src.Customer.Phone))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
            CreateMap<Subscription, CreateSubscriptionDTO>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ReverseMap();
            CreateMap<Subscription, UpdateSubscriptionDTO>()
                .ForMember(dest => dest.SubscriptionId, opt => opt.MapFrom(src => src.SubscriptionId))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ReverseMap();
        }
    }
}
