using CreciSP.Domain.Enum;
using CreciSP.Domain.Models;
using CreciSP.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Services.UserRepository
{
    public interface IUserRepository : IPersist
    {
        Task<ICollection<User>> GetUsersByFilters(string nome, string email, UserTypeEnum type);
    }
}
