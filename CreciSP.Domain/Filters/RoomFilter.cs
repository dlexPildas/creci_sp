using CreciSP.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Filters
{
    public class RoomFilter
    {
        public RoomFilter()
        {

        }
        public int? Number { get; set; }
        public int? Floor { get; set; }
        public int? Capacity { get; set; }
        public RoomType? Type { get; set; }
        public bool? Status { get; set; }
    }
}
