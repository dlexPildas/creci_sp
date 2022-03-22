using CreciSP.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Models
{
    public class LogNotify
    {
        public int Id { get; set; }

        public string Message { get; set; }
        public LogTypeEnum Type { get; set; } = LogTypeEnum.RemoveBooking;
        public DateTime ActionDate { get; set; }
        public bool IsViewed { get; set; } = false;

        public Guid ToUserId { get; set; }

        public virtual User ToUser { get; set; }
    }
}