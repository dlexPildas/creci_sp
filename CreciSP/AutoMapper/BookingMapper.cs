using AutoMapper;
using CreciSP.Domain.Models;
using CreciSP.Mvc.Dtos.UserDto;

namespace CreciSP.Mvc.AutoMapper
{
    public class BookingMapper : Profile
    {
        public BookingMapper()
        {
            CreateMap<BookingCreateDto, Booking>();
        }
    }
}
