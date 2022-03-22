using CreciSP.Domain.Models;
using CreciSP.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Services.LogNotifyRepository
{
    public interface ILogNotifyRepository : IPersist
    {
        Task<ICollection<LogNotify>> GetLogNotifyByUserId(Guid userId);
    }
}
