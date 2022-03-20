using AutoMapper;
using CreciSP.Application.Services.RoomService;
using CreciSP.Application.Services.UserService;
using CreciSP.Domain.Enum;
using CreciSP.Domain.Models;
using CreciSP.Mvc.Dtos.UserDto;
using Microsoft.AspNetCore.Mvc;
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
        /// Get user's list by filters
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="email"></param>
        /// <param name="type"></param>
        /// <returns>User's List</returns>
        [HttpGet]
        public async Task<IActionResult> GetUsersByFilters(string nome, string email, UserTypeEnum type)
        {
            var result = await _userService.GetUsers(nome, email, type);

            return Ok(result);
        }

        /// <summary>
        /// Create an User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>boolean if the user was created</returns>
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var valid = UserValidator(user);
            if (!valid.Key) return BadRequest(valid.Value);
            var result = await _userService.Create(user);

            return Ok(result);
        }
    }
}
