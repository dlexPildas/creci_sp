using _03.CreciSP.Domain.Notifier;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Domain.Services.BookingRepository;
using CreciSP.Domain.Services.RoomRepository;
using CreciSP.Repository.Repositories;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Application.Services.BookingService
{
    public class BookingService : NotifierService, IBookingService
    {
        private readonly IReadConnection _readConnection;
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IReadConnection readConnection, IBookingRepository bookingRepository)
        {
            _readConnection = readConnection;
            _bookingRepository = bookingRepository;
        }

        public override ValidationResult ValidationResult()
        {
            return GetValidationResult();
        }


        /// <summary>
        /// Cria uma Reserva
        /// </summary>
        /// <param name="room"></param>
        /// <returns>True se operação for realizada com Sucesso</returns>
        public async Task<bool> Create(Booking booking)
        {
            _bookingRepository.Add(booking);
            return await _bookingRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Buscar Reservas pelos filtros
        /// </summary>
        /// <param name="roomFilter"></param>
        /// <returns>Coleção de Reservas</returns>
        public async Task<ICollection<Booking>> GetBookingsByFilter(BookingFilter bookingFilter)
        {
            return await _bookingRepository.GetRoomsByFilters(bookingFilter);
        }

        /// <summary>
        /// Deletar Reserva
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Sucesso se operação for realizada com Sucesso</returns>
        public async Task<bool> DeleteBooking(Guid id)
        {
            var room = await _bookingRepository.GetBookingById(id);
            if (room == null)
            {
                AddValidationFailure("Reserva não encontrada!");
                return false;
            }
            _bookingRepository.Delete(room);

            return await _bookingRepository.SaveChangesAsync();
        }
    }
}
