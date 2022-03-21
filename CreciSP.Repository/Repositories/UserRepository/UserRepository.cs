using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Repository.Context;
using CreciSP.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Services.UserRepository
{
    public class UserRepository : Persist, IUserRepository
    {
        private readonly DataContext _dataContext;
        private readonly IReadConnection _readConnection;

        public UserRepository(DataContext dataContext, IReadConnection readConnection) : base(dataContext)
        {
            _dataContext = dataContext;
            _readConnection = readConnection;
        }

        public async Task<ICollection<User>> GetUsersByFilters(UserFilter userfilter)
        {
            var cmd = $@"SELECT [Id]
                               ,[Name]
                               ,[Cpf]
                               ,[Email]
                               ,[Type]
                               ,[Status]
                           FROM [dbo].[User] u
                           WHERE ({userfilter.Name} is null OR u.[Name] like '%{userfilter.Name}%') AND
                           ({userfilter.Cpf} is null OR u.[Cpf] like '%{userfilter.Cpf}%') AND
                           ({userfilter.Email} is null OR u.[Email] like '%{userfilter.Email}%') AND
                           ({userfilter.Type} is null OR u.[Type] = {userfilter.Type}') AND
                           ({userfilter.Status} is null OR u.[Status] = {userfilter.Status})";

            var result = await _readConnection.QueryAsync<User>(cmd);
            return result;
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
