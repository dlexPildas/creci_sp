using System;

namespace _01.CreciSP.Mvc.Dtos.BookingDto
{
    public class BookingReadDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public int NumberRoom { get; set; }
    }
}
