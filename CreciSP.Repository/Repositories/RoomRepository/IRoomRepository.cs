using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Services.RoomRepository
{
    public interface IRoomRepository : IPersist
    {
        List<Room> GetAllRooms();

        Task<Room> GetRoomById(Guid id);

        Task<ICollection<Room>> GetRoomsByFilters(RoomFilter filter);
    }
}
