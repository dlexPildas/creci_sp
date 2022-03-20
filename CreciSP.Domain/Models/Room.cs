using CreciSP.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Models
{
    public class Room
    {
        public Room()
        {
            
        }

        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Floor { get; set; }
        public string Capacity { get; set; }
        public RoomTypeEnum Type { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
