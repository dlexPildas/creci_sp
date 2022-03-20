using CreciSP.Domain.Enum;
using CreciSP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Application.Services.UserService
{
    public interface IUserService
    {
        Task<bool> Create(User user);

        Task<ICollection<User>> GetUsersByFilters(string nome, string email, UserTypeEnum type);
    }
}
