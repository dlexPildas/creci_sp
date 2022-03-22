using CreciSP.Domain.Models;
using CreciSP.Repository.Context;
using CreciSP.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Services.LogNotifyRepository
{
    public class LogNotifyRepository : Persist, ILogNotifyRepository
    {
        private readonly DataContext _dataContext;
        private readonly IReadConnection _readConnection;
        public LogNotifyRepository(DataContext dataContext, IReadConnection readConnection) : base(dataContext)
        {
            _dataContext = dataContext;
            _readConnection = readConnection;
        }


        public async Task<ICollection<LogNotify>> GetLogNotifyByUserId(Guid toUserId)
        {
            var cmd = $@" SELECT [Id]
                                ,[Message]
                                ,[Type]
                                ,[ActionDate]
                                ,[IsViewed]
                                ,[ToUserId]
                            FROM [dbo].[LogNotify] ln
                            WHERE ln.ToUserId = '@ToUserId'";
            var parameters = new
            {
                ToUserId = toUserId
            };

            var result = await _readConnection.QueryAsync<LogNotify>(cmd, parameters);
            return result;
        }
    }
}
