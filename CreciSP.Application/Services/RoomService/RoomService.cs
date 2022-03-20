


using CreciSP.Domain.Models;
using CreciSP.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreciSP.Application.Services.RoomService
{
    public class RoomService : IRoomService
    {
        private readonly IReadConnection _readConnection;

        public RoomService(IReadConnection readConnection)
        {
            _readConnection = readConnection;
        }

        public async Task<ICollection<Room>> GetRooms()
        {
            var cmd = "SELECT * FROM Room";

            try
            {
                var result = await _readConnection.QueryAsync<Room>(cmd);

                return result;
            }
            catch (Exception e)
            {
                return null;
            }

            
        }
    }
}
