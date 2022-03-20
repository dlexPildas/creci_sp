using CreciSP.Domain.Enum;
using CreciSP.Domain.Models;
using CreciSP.Domain.Services.UserRepository;
using CreciSP.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IReadConnection _readConnection;
        private readonly IUserRepository _userRepository;

        public UserService(IReadConnection readConnection, IUserRepository userRepository)
        {
            _readConnection = readConnection;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Create an User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>boolean if the user was created</returns>
        public async Task<bool> Create(User user)
        {
             _userRepository.Add(user);
            return await _userRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Get user's list by filters
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="email"></param>
        /// <param name="type"></param>
        /// <returns>User's List</returns>
        public async Task<ICollection<User>> GetUsersByFilters(string nome, string email, UserTypeEnum type)
        {
            return await _userRepository.GetUsersByFilters(nome, email, type);
        }

    }
}
