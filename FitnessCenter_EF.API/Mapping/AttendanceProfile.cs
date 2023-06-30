using AutoMapper;
using FitnessCenter_EF.BLL.DTOs.Attendance;
using FitnessCenter_EF.DAL.Models;

namespace FitnessCenter_EF.API.Mapping
{
    public class AttendanceProfile : Profile
    {
        public AttendanceProfile()
        {
            CreateMap<Attendance, AttendanceDTO>()
                .ForMember(dest => dest.AttendanceId, opt => opt.MapFrom(src => src.AttendanceId))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => $"{src.Customer.FirstName} {src.Customer.LastName}"))
                .ForMember(dest => dest.AttendanceDate, opt => opt.MapFrom(src => src.AttendanceDate))
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => $"{src.Class.ClassName}"));
            CreateMap<Attendance, CreateAttendanceDTO>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.AttendanceDate, opt => opt.MapFrom(src => src.AttendanceDate))
                .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassId))
                .ReverseMap();
            CreateMap<Attendance, UpdateAttendanceDTO>()
                .ForMember(dest => dest.AttendanceId, opt => opt.MapFrom(src => src.AttendanceId))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.AttendanceDate, opt => opt.MapFrom(src => src.AttendanceDate))
                .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassId))
                .ReverseMap();
        }
    }
}
