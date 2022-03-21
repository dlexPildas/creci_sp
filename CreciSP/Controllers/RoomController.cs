using AutoMapper;
using CreciSP.Application.Services.RoomService;
using CreciSP.Domain.Models;
using CreciSP.Mvc.Dtos.RoomDto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CreciSP.Mvc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;


        public RoomController(
            IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        /// <summary>
        /// Cria uma Sala
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        [HttpPost]
        public async Task<IActionResult> Create(RoomCreateDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            var result = await _roomService.Create(room);

            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var result = await _roomService.GetRooms();

            return Ok(result);
        }
    }
}
