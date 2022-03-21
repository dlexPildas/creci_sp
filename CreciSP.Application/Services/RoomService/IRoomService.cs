using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _03.CreciSP.Domain.Notifier;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;

namespace CreciSP.Application.Services.RoomService
{
    public interface IRoomService : INotifierService
    {
        Task<bool> Create(Room room);

        Task<bool> InactiveRoom(Guid id);

        Task<bool> ActiveRoom(Guid id);

        Task<ICollection<Room>> GetRoomsByFilter(RoomFilter roomFilter);



    }
}
