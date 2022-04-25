using _01.CreciSP.Mvc.Dtos.BookingDto;
using AutoMapper;
using CreciSP.Domain.Models;
using CreciSP.Mvc.Dtos.BookingDto;
using System;

namespace CreciSP.Mvc.AutoMapper
{
    public class BookingMapper : Profile
    {
        public BookingMapper()
        {
            CreateMap<BookingCreateDto, Booking>()
                .ForMember(x => x.StartTime, y => y.MapFrom(z => TimeSpan.Parse(z.StartTime)))
                .ForMember(x => x.EndTime, y => y.MapFrom(z => TimeSpan.Parse(z.EndTime)));

            CreateMap<Booking, BookingReadDto>()
                .ForMember(x => x.StartTime, y => y.MapFrom(z => $"{z.StartTime.Hours}:{z.StartTime.Minutes}"))
                .ForMember(x => x.EndTime, y => y.MapFrom(z => $"{z.EndTime.Hours}:{z.EndTime.Minutes}"));
        }
    }
}
