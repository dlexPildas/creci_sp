using System.Collections.Generic;
using System.Threading.Tasks;
using CreciSP.Domain.Models;

namespace CreciSP.Application.Services.RoomService
{
    public interface IRoomService
    {
        Task<ICollection<Room>> GetRooms();
    }
}
