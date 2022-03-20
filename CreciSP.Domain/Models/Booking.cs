using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Models
{
    public class Booking
    {
        public Booking()
        {
            
        }

        public Guid Id { get;  private set; }
        public DateTime Date { get;  private set; }
        public TimeSpan StartTime { get;  private set; }
        public TimeSpan EndTime { get;  private set; }

        public Guid RoomId { get;  private set; }
        public virtual Room Room { get;  private set; }

        public Guid UserId { get;  private set; }
        public virtual User User { get;  private set; }
    }
}
