using AutoMapper;
using FitnessCenter_EF.BLL.DTOs.EquipmentClass;
using FitnessCenter_EF.DAL.Models;

namespace FitnessCenter_EF.API.Mapping
{
    public class EquipmentClassProfile : Profile
    {
        public EquipmentClassProfile()
        {
            CreateMap<EquipmentClass, EquipmentClassDTO>()
                .ForMember(dest => dest.EquipmentName, opt => opt.MapFrom(src => src.Equipment.EquipmentName))
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class.ClassName));
            CreateMap<EquipmentClass, CreateEquipmentClassDTO>()
                .ForMember(dest => dest.EquipmentId, opt => opt.MapFrom(src => src.EquipmentId))
                .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassId))
                .ReverseMap();
            CreateMap<EquipmentClass, UpdateEquipmentClassDTO>()
                .ForMember(dest => dest.EquipmentId, opt => opt.MapFrom(src => src.EquipmentId))
                .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassId))
                .ReverseMap();
        }
    }
}
