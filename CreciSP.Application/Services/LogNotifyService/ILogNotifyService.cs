using _03.CreciSP.Domain.Notifier;
using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Application.Services.LogNotifyService
{
    public interface ILogNotifyService : INotifierService
    {
        Task<ICollection<LogNotify>> GetLogNotifyByUserId(Guid userId);
    }
}
