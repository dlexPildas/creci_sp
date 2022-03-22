using CreciSP.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Filters
{
    public class EquipmentFilter
    {
        public EquipmentFilter()
        {

        }
        public int Number { get; set; }
        public EquipmentTypeEnum Type { get; set; }
        public string Description { get; set; }
        public Guid? RoomId { get; set; }
    }
}
