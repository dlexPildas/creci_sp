using System.Collections.Generic;
using CreciSP.Domain.Models;

namespace CreciSP.Domain.Services.RoomService
{
    public interface IRoomService
    {
        List<Room> GetRooms();
    }
}
