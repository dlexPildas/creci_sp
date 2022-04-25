using CreciSP.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Filters
{
    public class BookingFilter
    {
        public BookingFilter()
        {

        }
        public DateTime? Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public Guid? RoomId { get; set; }
        public Guid? UserId { get; set; }
    }
}
