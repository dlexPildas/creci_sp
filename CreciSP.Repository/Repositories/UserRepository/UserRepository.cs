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

        public async Task<ICollection<User>> GetUsersByFilters(UserFilter userFilter)
        {
            var cmd = $@"SELECT [Id]
                               ,[Name]
                               ,[Cpf]
                               ,[Email]
                               ,[Type]
                               ,[Status]
                           FROM [dbo].[User] u
                           WHERE (@Name is null OR u.[Name] like '%@Name%') AND
                           (@Cpf is null OR u.[Cpf] like '%@Cpf%') AND
                           (@Email is null OR u.[Email] like '%@Email%') AND
                           (@Type is null OR u.[Type] = @Type) AND
                           (@Status is null OR u.[Status] = @Status)";
            var parameters = new
            {
                Name = userFilter.Name,
                Cpf = userFilter.Cpf,
                Email = userFilter.Email,
                Type = userFilter.Type,
                Status = userFilter.Status
            };
            var result = await _readConnection.QueryAsync<User>(cmd, parameters);
            return result;
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
