﻿using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
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
        /// Cria um Usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        public async Task<bool> Create(User user)
        {
             _userRepository.Add(user);
            return await _userRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Buscar lista de usuários com base nos parâmetros
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="email"></param>
        /// <param name="type"></param>
        /// <returns>Lsta de Usuários</returns>
        public async Task<ICollection<User>> GetUsersByFilters(UserFilter userfilter)
        {
            return await _userRepository.GetUsersByFilters(userfilter);
        }

        /// <summary>
        /// Buscar Usuário pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuário</returns>
        public async Task<User> GetUserById(Guid id)
        {
            return await _userRepository.GetUserById(id);
        }

        /// <summary>
        /// Desativer Usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        public async Task<bool> InactiveUser(Guid id)
        {
            var user = await _userRepository.GetUserById(id);
            user.InactiveUser();
            return await _userRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Active Usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        public async Task<bool> ActiveUser(Guid id)
        {
            var user = await _userRepository.GetUserById(id);
            user.ActiveUser();
            return await _userRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Atualizar informações do Usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        public async Task<bool> UpdateUser(User user)
        {
            var userDataBase = await _userRepository.GetUserById(user.Id);
            userDataBase.UpdateUser(user);
            return await _userRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Mudar Senha do usuário
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        public async Task<bool> ChangePasswordUser(Guid id, string password, string newPassword)
        {
            var userDataBase = await _userRepository.GetUserById(id);
            if (userDataBase.Password != password)
                throw new Exception();

            userDataBase.ChangePassword(newPassword);

            return await _userRepository.SaveChangesAsync();
        }

    }
}
