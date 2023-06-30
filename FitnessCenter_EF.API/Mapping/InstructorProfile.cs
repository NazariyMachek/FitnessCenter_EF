using AutoMapper;
using FitnessCenter_EF.BLL.DTOs.Instructor;
using FitnessCenter_EF.DAL.Models;

namespace FitnessCenter_EF.API.Mapping
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<Instructor, InstructorDTO>()
                .ForMember(dest => dest.InstructorId, opt => opt.MapFrom(src => src.InstructorId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Specialization, opt => opt.MapFrom(src => src.Specialization));
            CreateMap<Instructor, CreateInstructorDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Specialization, opt => opt.MapFrom(src => src.Specialization))
                .ReverseMap();
            CreateMap<Instructor, UpdateInstructorDTO>()
                .ForMember(dest => dest.InstructorId, opt => opt.MapFrom(src => src.InstructorId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Specialization, opt => opt.MapFrom(src => src.Specialization))
                .ReverseMap();
        }
    }
}
