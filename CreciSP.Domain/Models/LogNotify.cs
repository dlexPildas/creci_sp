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

        public string Message { get; private set; }
        public LogTypeEnum Type { get; private set; } = LogTypeEnum.RemoveBooking;
        public DateTime ActionDate { get; private set; }
        public bool IsViewed { get; private set; } = false;

        public Guid ToUserId { get; private set; }

        public virtual User ToUser { get; private set; }


        public LogNotify(string message, LogTypeEnum type, DateTime actionDate, bool isViewed, Guid toUserId)
        {
            Message = message;
            Type = type;
            ActionDate = actionDate;
            IsViewed = isViewed;
            ToUserId = toUserId;
        }
    }
}