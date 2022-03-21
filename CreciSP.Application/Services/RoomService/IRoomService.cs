using System.Collections.Generic;
using System.Threading.Tasks;
using _03.CreciSP.Domain.Notifier;
using CreciSP.Domain.Models;

namespace CreciSP.Application.Services.RoomService
{
    public interface IRoomService : INotifierService
    {
        Task<ICollection<Room>> GetRooms();

        Task<bool> Create(Room room);
    }
}
