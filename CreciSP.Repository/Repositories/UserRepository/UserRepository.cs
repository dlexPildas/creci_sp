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

        public async Task<ICollection<User>> GetUsersByFilters(UserFilter filter)
        {
            var cmd = $@"SELECT [Id]
                               ,[Name]
                               ,[Cpf]
                               ,[Email]
                               ,[Type]
                               ,[Status]
                           FROM [dbo].[User] u
                           WHERE 1=1
                            {(filter.Name != default ? $"AND (u.[Name] like '%{filter.Name}%')" : "")}
                            {(filter.Cpf != default ? $"AND ( u.[Name] like '%{filter.Cpf}%')" : "")}
                            {(filter.Email != default ? $"AND (u.[Email] like '{filter.Email}')" : "")}
                            {(filter.Type != default ? $"AND (u.[Type] = {(int)filter.Type})" : "")}
                            {(filter.Status != default ? $"AND (u.[Status] = {(filter.Status.Value ? 1 : 0)})" : "")}";
           
            var result = await _readConnection.QueryAsync<User>(cmd);
            return result;
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
