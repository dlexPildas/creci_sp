using CreciSP.Domain.Enum;

namespace CreciSP.Mvc.Dtos.UserDto
{
    public class RoomCreateDto
    {
        public int Number { get; private set; }
        public int Floor { get; private set; }
        public int Capacity { get; private set; }
        public RoomTypeEnum Type { get; private set; }
    }
}
