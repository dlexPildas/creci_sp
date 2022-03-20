using System;

namespace CreciSP.Mvc.Dtos.UserDto
{
    public class BookingCreateDto
    {
        public DateTime Date { get; private set; }
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }
        public Guid Userd { get; private set; }
        public Guid RoomId { get; private set; }
    }
}
