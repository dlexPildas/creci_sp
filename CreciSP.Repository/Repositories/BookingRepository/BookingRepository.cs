
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

        public async Task<ICollection<Booking>> GetBookingByFilters(BookingFilter filter)
        {
            var cmd = $@"SELECT [Id]
                               ,[Date]
                               ,[StartTime]
                               ,[EndTime]
                               ,[RoomId]
                               ,[UserId]
                           FROM [dbo].[Booking] b
                           WHERE (@Date is null OR r.[Date] = '@Date') AND
                           (@RoomId is null OR r.[RoomId] = @RoomId) AND
                           (@UserId is null OR r.[UserId] = @UserId)";

            var parameters = new
            {
                Date = filter.Date,
                RoomId = filter.RoomId,
                UserId = filter.UserId
            };

            var result = await _readConnection.QueryAsync<Booking>(cmd, parameters);
            return result;
        }

        public Task<Booking> GetBookingById(Guid id)
        {
            return _dataContext.Bookings.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
