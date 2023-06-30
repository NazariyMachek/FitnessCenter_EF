using AutoMapper;
using FitnessCenter_EF.BLL.DTOs.Booking;
using FitnessCenter_EF.DAL.Models;

namespace FitnessCenter_EF.API.Mapping
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingDTO>()
                .ForMember(dest => dest.BookingId, opt => opt.MapFrom(src => src.BookingId))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => $"{src.Customer.FirstName} {src.Customer.LastName}"))
                .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(src => src.BookingDate))
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => $"{src.Class.ClassName}"));
            CreateMap<Booking, CreateBookingDTO>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(src => src.BookingDate))
                .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassId))
                .ReverseMap();
            CreateMap<Booking, UpdateBookingDTO>()
                .ForMember(dest => dest.BookingId, opt => opt.MapFrom(src => src.BookingId))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(src => src.BookingDate))
                .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassId))
                .ReverseMap();
        }
    }
}
