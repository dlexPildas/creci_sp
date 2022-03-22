using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Repository.Context;
using CreciSP.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Services.RoomRepository
{
    public class RoomRepository : Persist, IRoomRepository 
    {
        private readonly DataContext _dataContext;
        private readonly IReadConnection _readConnection;

        public RoomRepository(DataContext dataContext, IReadConnection readConnection) : base(dataContext)
        {
            _dataContext = dataContext;
            _readConnection = readConnection;
        }

        public List<Room> GetAllRooms()
        {
           var result =  _dataContext.Rooms.ToList();

            return result;
        }

        public Task<Room> GetRoomById(Guid id)
        {
            return _dataContext.Rooms.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Room>> GetRoomsByFilters(RoomFilter filter)
        {
            var cmd = $@"SELECT [Id]
                               ,[Number]
                               ,[Floor]
                               ,[Capacity]
                               ,[Type]
                               ,[Status]
                           FROM [dbo].[Room] r
                           WHERE (@Number is null OR r.[Number] = @Number ) AND
                           (@Floor is null OR r.[Floor] = @Number ) AND
                           (@Capacity is null OR r.[Capacity] = @Number ) AND
                           (@Type is null OR r.[Type] = @Number ) AND
                           (@Status is null OR r.[Type] = @Number )";

            var parameters = new
            {
                Number = filter.Number,
                Floor = filter.Floor,
                Capacity = filter.Capacity,
                Type = filter.Type,
                Status = filter.Status
            };

            var result = await _readConnection.QueryAsync<Room>(cmd, parameters);
            return result;
        }
    }
}
