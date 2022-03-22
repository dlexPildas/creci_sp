using _01.CreciSP.Mvc.Extensions;
using AutoMapper;
using CreciSP.Application.Services.BookingService;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Mvc.Dtos.BookingDto;
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
        /// Cria uma Reserva
        /// </summary>
        /// <param name="bookingDto"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        [HttpPost]
        public async Task<IActionResult> Create(BookingCreateDto bookingDto)
        {
            var booking = _mapper.Map<Booking>(bookingDto);

            ModelState.AddValidationResult(await _validatorFactory.GetValidator<Booking>().ValidateAsync(booking));
            if (!ModelState.IsValid)
                return Conflict(ModelState.GetValidationProblemDetails());

            var result = await _bookingService.Create(booking);

            return Ok(result);
        }

        /// <summary>
        /// Buscar Reservas pelos filtros
        /// </summary>
        /// <param name="bookingFilter"></param>
        /// <returns>Coleção de Reservas</returns>
        [HttpGet]
        public async Task<IActionResult> GetBookingsByFilter(BookingFilter bookingFilter)
        {
            var result = await _bookingService.GetBookingsByFilter(bookingFilter);

            return Ok(result);
        }

        

        /// <summary>
        /// Deletar Sala
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Sucesso se operação for realizada com Sucesso</returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBooking(Guid id, bool isAdministrator)
        {
            await _bookingService.DeleteBooking(id, isAdministrator);

            ModelState.AddValidationResult(_bookingService.ValidationResult());
            if (!ModelState.IsValid)
                return Conflict(ModelState.GetValidationProblemDetails());

            return Ok();
        }
    }
}
