using AutoMapper;
using CreciSP.Domain.Models;
using CreciSP.Mvc.Dtos.UserDto;

namespace CreciSP.Mvc.AutoMapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserCreateDto, Booking>();
            CreateMap<RoomCreateDto, Room>();
            CreateMap<BookingCreateDto, Booking>();
        }
    }
}
