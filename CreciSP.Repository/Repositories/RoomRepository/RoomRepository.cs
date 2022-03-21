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

        public async Task<ICollection<Room>> GetRoomsByFilters(RoomFilter roomFilter)
        {
            var cmd = $@"SELECT [Id]
                               ,[Number]
                               ,[Floor]
                               ,[Capacity]
                               ,[Type]
                               ,[Status]
                           FROM [dbo].[Room] r
                           ({roomFilter.Number} is null OR r.[Number] = {roomFilter.Number}) AND
                           ({roomFilter.Floor} is null OR r.[Floor] = {roomFilter.Floor}) AND
                           ({roomFilter.Capacity} is null OR r.[Capacity] = {roomFilter.Capacity}) AND
                           ({roomFilter.Type} is null OR r.[Type] = {roomFilter.Type}) AND
                           ({roomFilter.Status} is null OR r.[Type] = {roomFilter.Status})";

            var result = await _readConnection.QueryAsync<Room>(cmd);
            return result;
        }
    }
}
