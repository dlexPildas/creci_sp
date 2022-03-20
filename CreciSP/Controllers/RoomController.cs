using CreciSP.Domain.Services.RoomService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CreciSP.Mvc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(
            IRoomService roomService)
        {
            _roomService = roomService;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(new
            {
                Id =  0,
                Name = "Daniel"
            });
        }
    }
}
