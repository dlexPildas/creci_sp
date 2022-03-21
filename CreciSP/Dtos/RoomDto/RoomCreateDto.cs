using CreciSP.Domain.Enum;

namespace CreciSP.Mvc.Dtos.RoomDto
{
    public class RoomCreateDto
    {
        public int Number { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }
        public RoomTypeEnum Type { get; set; }
    }
}
