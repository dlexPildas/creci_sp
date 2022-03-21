using System;

namespace CreciSP.Mvc.Dtos.UserDto
{
    public class BookingCreateDto
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Guid Userd { get; set; }
        public Guid RoomId { get; set; }
    }
}
