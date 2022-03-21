using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
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

        Task<ICollection<User>> GetUsersByFilters(UserFilter userfilter);

        Task<User> GetUserById(Guid id);

        Task<bool> InactiveUser(Guid id);

        Task<bool> ActiveUser(Guid id);

        Task<bool> UpdateUser(User user);

        Task<bool> ChangePasswordUser(Guid id, string password, string newPassword);
    }
}
