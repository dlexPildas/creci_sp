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
        public int? Number { get; private set; }
        public int? Floor { get; private set; }
        public int? Capacity { get; private set; }
        public RoomType? Type { get; private set; }
        public bool? Status { get; private set; }
    }
}
