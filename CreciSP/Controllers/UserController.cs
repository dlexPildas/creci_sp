using AutoMapper;
using CreciSP.Application.Services.RoomService;
using CreciSP.Application.Services.UserService;
using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Mvc.Dtos.UserDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CreciSP.Mvc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// Cria um Usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var result = await _userService.Create(user);

            return Ok(result);
        }

        /// <summary>
        /// Buscar lista de usuários com base nos parâmetros
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="email"></param>
        /// <param name="type"></param>
        /// <returns>Lsta de Usuários</returns>
        [HttpGet]
        public async Task<IActionResult> GetUsersByFilters([FromQuery]UserFilter userfilter)
        {
            var result = await _userService.GetUsersByFilters(userfilter);
            return Ok(result);
        }

        /// <summary>
        /// Buscar Usuário pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuário</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<User> GetUserById(Guid id)
        {
            return await _userService.GetUserById(id);
        }

        /// <summary>
        /// Desativer Usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        [HttpPut]
        [Route("{id}/inactive")]
        public async Task<bool> InactiveUser(Guid id)
        {
            return await _userService.InactiveUser(id);
        }

        /// <summary>
        /// Ativar Usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        [HttpPut]
        [Route("{id}/active")]
        public async Task<bool> ActiveUser(Guid id)
        {
            return await _userService.ActiveUser(id);
        }

        /// <summary>
        /// Atualizar informações do Usuário
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        [HttpPut]
        public async Task<bool> UpdateUser(UserUpdateDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            return await _userService.UpdateUser(user);
        }

        /// <summary>
        /// Mudar Senha do usuário
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        [HttpPut]
        [Route("change-password")]
        public async Task<bool> ChangePasswordUser(UserChangePasswordDto userDto)
        {
            return await _userService.ChangePasswordUser(userDto.Id, userDto.Password, userDto.NewPassword);
        }


    }
}
