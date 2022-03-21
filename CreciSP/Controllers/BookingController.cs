using _01.CreciSP.Mvc.Extensions;
using AutoMapper;
using CreciSP.Application.Services.BookingService;
using CreciSP.Application.Services.RoomService;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Mvc.Dtos.BookingDto;
using CreciSP.Mvc.Dtos.RoomDto;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CreciSP.Mvc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        private readonly IValidatorFactory _validatorFactory;

        public BookingController(
            IBookingService bookingService, IMapper mapper, IValidatorFactory validatorFactory)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _validatorFactory = validatorFactory;
        }

        /// <summary>
        /// Cria uma Sala
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        [HttpPost]
        public async Task<IActionResult> Create(BookingCreateDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);

            ModelState.AddValidationResult(await _validatorFactory.GetValidator<Room>().ValidateAsync(room));
            if (!ModelState.IsValid)
                return Conflict(ModelState.GetValidationProblemDetails());

            var result = await bookingService.Create(room);

            return Ok(result);
        }

        /// <summary>
        /// Buscar Salas pelos filtros
        /// </summary>
        /// <param name="roomFilter"></param>
        /// <returns>Coleção de Salas</returns>
        [HttpGet]
        public async Task<IActionResult> GetRoomsByFilter(RoomFilter roomFilter)
        {
            var result = await _roomService.GetRoomsByFilter(roomFilter);

            return Ok(result);
        }

        /// <summary>
        /// Desativar Sala
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        [HttpPut]
        [Route("{id}/inactive")]
        public async Task<IActionResult> InactiveUser(Guid id)
        {
            await _roomService.InactiveRoom(id);

            ModelState.AddValidationResult(_roomService.ValidationResult());
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
            await _roomService.ActiveRoom(id);

            ModelState.AddValidationResult(_roomService.ValidationResult());
            if (!ModelState.IsValid)
                return Conflict(ModelState.GetValidationProblemDetails());

            return Ok();
        }

        /// <summary>
        /// Deletar Sala
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Sucesso se operação for realizada com Sucesso</returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRoom(Guid id)
        {
            await _roomService.DeleteRoom(id);

            ModelState.AddValidationResult(_roomService.ValidationResult());
            if (!ModelState.IsValid)
                return Conflict(ModelState.GetValidationProblemDetails());

            return Ok();
        }
    }
}
