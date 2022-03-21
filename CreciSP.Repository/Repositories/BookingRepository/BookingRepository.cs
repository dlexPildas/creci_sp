
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Repository.Context;
using CreciSP.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreciSP.Domain.Services.BookingRepository
{
    public class BookingRepository : Persist, IBookingRepository
    {
        private readonly DataContext _dataContext;
        private readonly IReadConnection _readConnection;

        public BookingRepository(DataContext dataContext, IReadConnection readConnection) : base(dataContext)
        {
            _dataContext = dataContext;
            _readConnection = readConnection;
        }

        public async Task<ICollection<Booking>> GetRoomsByFilters(BookingFilter bookingFilter)
        {
            var cmd = $@"SELECT [Id]
                               ,[Date]
                               ,[StartTime]
                               ,[EndTime]
                               ,[RoomId]
                               ,[UserId]
                           FROM [dbo].[Booking] b
                           ({bookingFilter.Date} is null OR r.[Date] = '{bookingFilter.Date.ToString("yyyy-MM-dd")}') AND
                           ({bookingFilter.StartTime} is null OR r.[StartTime] = {bookingFilter.StartTime}) AND
                           ({bookingFilter.EndTime} is null OR r.[EndTime] = {bookingFilter.EndTime}) AND
                           ({bookingFilter.RoomId} is null OR r.[RoomId] = {bookingFilter.RoomId}) AND
                           ({bookingFilter.UserId} is null OR r.[UserId] = {bookingFilter.UserId})";

            var result = await _readConnection.QueryAsync<Booking>(cmd);
            return result;
        }

        public Task<Booking> GetBookingById(Guid id)
        {
            return _dataContext.Bookings.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
