using _01.CreciSP.Mvc.Extensions;
using AutoMapper;
using CreciSP.Application.Services.RoomService;
using CreciSP.Application.Services.UserService;
using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Mvc.Dtos.UserDto;
using FluentValidation;
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
        private readonly IValidatorFactory _validatorFactory;

        public UserController(IUserService userService, IMapper mapper, IValidatorFactory validatorFactory)
        {
            _userService = userService;
            _mapper = mapper;
            _validatorFactory = validatorFactory;
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

            ModelState.AddValidationResult(await _validatorFactory.GetValidator<User>().ValidateAsync(user));
            if (!ModelState.IsValid)
                return Conflict(ModelState.GetValidationProblemDetails());

            var result = await _userService.Create(user);

            return Ok(result);
        }

        /// <summary>
        /// Buscar coleção de usuários com base nos parâmetros
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="email"></param>
        /// <param name="type"></param>
        /// <returns>Coleção de Usuários</returns>
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
        /// Desativar Usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        [HttpPut]
        [Route("{id}/inactive")]
        public async Task<IActionResult> InactiveUser(Guid id)
        {
             await _userService.InactiveUser(id);

            ModelState.AddValidationResult(_userService.ValidationResult());
            if (!ModelState.IsValid)
                return Conflict(ModelState.GetValidationProblemDetails());

            return Ok();
        }

        /// <summary>
        /// Ativar Usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        [HttpPut]
        [Route("{id}/active")]
        public async Task<IActionResult> ActiveUser(Guid id)
        {
            await _userService.ActiveUser(id);

            ModelState.AddValidationResult(_userService.ValidationResult());
            if (!ModelState.IsValid)
                return Conflict(ModelState.GetValidationProblemDetails());

            return Ok();
        }

        /// <summary>
        /// Atualizar informações do Usuário
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns>Retorna sucesso se o usuário for atualizado</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            ModelState.AddValidationResult(await _validatorFactory.GetValidator<User>().ValidateAsync(user));
            if (!ModelState.IsValid)
                return Conflict(ModelState.GetValidationProblemDetails());

            await _userService.UpdateUser(user);

            ModelState.AddValidationResult(_userService.ValidationResult());
            if (!ModelState.IsValid)
                return Conflict(ModelState.GetValidationProblemDetails());

            return Ok();
        }

        /// <summary>
        /// Mudar Senha do usuário
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns>Retorna sucesso se a senha do usuário for trocada</returns>
        [HttpPut]
        [Route("change-password")]
        public async Task<IActionResult> ChangePasswordUser(UserChangePasswordDto userDto)
        {
            await _userService.ChangePasswordUser(userDto.Id, userDto.Password, userDto.NewPassword);

            ModelState.AddValidationResult(_userService.ValidationResult());
            if (!ModelState.IsValid)
                return Conflict(ModelState.GetValidationProblemDetails());

            return Ok();
        }


    }
}
