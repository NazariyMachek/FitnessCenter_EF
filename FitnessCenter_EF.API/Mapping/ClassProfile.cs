using AutoMapper;
using FitnessCenter_EF.BLL.DTOs.Class;
using FitnessCenter_EF.DAL.Models;

namespace FitnessCenter_EF.API.Mapping
{
    public class ClassProfile : Profile
    {
        public ClassProfile()
        {
            CreateMap<Class, ClassDTO>()
                .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassId))
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => $"{src.Instructor.FirstName} {src.Instructor.LastName}"))
                .ForMember(dest => dest.Schedule, opt => opt.MapFrom(src => src.Schedule));
            CreateMap<Class, CreateClassDTO>()
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(dest => dest.InstructorId, opt => opt.MapFrom(src => src.InstructorId))
                .ForMember(dest => dest.Schedule, opt => opt.MapFrom(src => src.Schedule))
                .ForMember(dest => dest.MaxCapacity, opt => opt.MapFrom(src => src.MaxCapacity))
                .ReverseMap();
            CreateMap<Class, UpdateClassDTO>()
                .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassId))
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(dest => dest.InstructorId, opt => opt.MapFrom(src => src.InstructorId))
                .ForMember(dest => dest.Schedule, opt => opt.MapFrom(src => src.Schedule))
                .ForMember(dest => dest.MaxCapacity, opt => opt.MapFrom(src => src.MaxCapacity))
                .ReverseMap();
        }
    }
}
