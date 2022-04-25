using System;

namespace CreciSP.Mvc.Dtos.BookingDto
{
    public class BookingCreateDto
    {
        public DateTime? Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
    }
}
