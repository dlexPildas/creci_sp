using CreciSP.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Models
{
    public class Equipment
    {  

        public Guid Id { get;  private set; }
        public int Number { get;  private set; }
        public EquipmentType Type { get;  private set; }
        public string Description { get;  private set; }        
        public Guid? RoomId { get;  private set; }
        public virtual Room Room { get;  private set; }

        public Equipment() {}
        

        public void UnlinkRoom()
        {
            RoomId = null;
        }

        public void LinkRoom(Guid roomId)
        {
            RoomId = roomId;
        }
    }
}
