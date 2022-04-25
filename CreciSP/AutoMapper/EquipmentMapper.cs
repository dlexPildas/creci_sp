using AutoMapper;
using CreciSP.Domain.Models;
using CreciSP.Mvc.Dtos.EquipmentDto;
using CreciSP.Mvc.Dtos.UserDto;

namespace CreciSP.Mvc.AutoMapper
{
    public class EquipmentMapper : Profile
    {
        public EquipmentMapper()
        {
            CreateMap<EquipmentCreateDto, Equipment>();
        }
    }
}
