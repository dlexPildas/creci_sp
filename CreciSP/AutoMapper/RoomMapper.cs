using AutoMapper;
using CreciSP.Domain.Models;
using CreciSP.Mvc.Dtos.RoomDto;

namespace CreciSP.Mvc.AutoMapper
{
    public class RoomMapper : Profile
    {
        public RoomMapper()
        {
            CreateMap<RoomCreateDto, Room>();
        }
    }
}
