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

        public Guid Id { get;  private set; }
        public int Number { get;  private set; }
        public int Floor { get; private set; }
        public int Capacity { get;  private set; }
        public RoomTypeEnum Type { get;  private set; }
        public bool Status { get;  private set; }

        public virtual ICollection<Booking> Bookings { get;  private set; }

        public void ActiveRoom()
        {
            Status = true;
        }

        public void InactiveRoom()
        {
            Status = false;
        }
    }
}
