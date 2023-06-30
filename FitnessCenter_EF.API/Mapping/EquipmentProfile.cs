using AutoMapper;
using FitnessCenter_EF.BLL.DTOs.Equipment;
using FitnessCenter_EF.DAL.Models;

namespace FitnessCenter_EF.API.Mapping
{
    public class EquipmentProfile : Profile
    {
        public EquipmentProfile()
        {
            CreateMap<Equipment, EquipmentDTO>()
                .ForMember(dest => dest.EquipmentId, opt => opt.MapFrom(src => src.EquipmentId))
                .ForMember(dest => dest.EquipmentName, opt => opt.MapFrom(src => src.EquipmentName))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
            CreateMap<Equipment, CreateEquipmentDTO>()
                .ForMember(dest => dest.EquipmentName, opt => opt.MapFrom(src => src.EquipmentName))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ReverseMap();
            CreateMap<Equipment, UpdateEquipmentDTO>()
                .ForMember(dest => dest.EquipmentId, opt => opt.MapFrom(src => src.EquipmentId))
                .ForMember(dest => dest.EquipmentName, opt => opt.MapFrom(src => src.EquipmentName))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ReverseMap();
        }
    }
}
