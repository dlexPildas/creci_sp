using _03.CreciSP.Domain.Notifier;
using CreciSP.Domain.Enum;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Domain.Services.BookingRepository;
using CreciSP.Domain.Services.LogNotifyRepository;
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
        private readonly ILogNotifyRepository _logNotifyRepository;

        public BookingService(IReadConnection readConnection, IBookingRepository bookingRepository, ILogNotifyRepository logNotifyRepository)
        {
            _readConnection = readConnection;
            _bookingRepository = bookingRepository;
            _logNotifyRepository = logNotifyRepository;
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
        /// <param name="bookingFilter"></param>
        /// <returns>Coleção de Reservas</returns>
        public async Task<ICollection<Booking>> GetBookingsByFilter(BookingFilter bookingFilter)
        {
            return await _bookingRepository.GetBookingsByFilter(bookingFilter);
        }

        /// <summary>
        /// Deletar Reserva
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Sucesso se operação for realizada com Sucesso</returns>
        public async Task<bool> DeleteBooking(Guid id, bool isAdmintrator)
        {
            var booking = await _bookingRepository.GetBookingById(id);
            if (booking == null)
            {
                AddValidationFailure("Reserva não encontrada!");
                return false;
            }

            if (isAdmintrator)
            {
                var Message = $"Reserva Sala {booking.Room.Number} no dia {booking.Date.ToString("dd/MM/yyyy")} das {booking.StartTime.ToString()} às {booking.EndTime.ToString()}";
                var logNotify = new LogNotify(Message, LogType.RemoveBooking, DateTime.Now, false, booking.UserId);
                _logNotifyRepository.Add(logNotify);

                await _logNotifyRepository.SaveChangesAsync();
            }


            _bookingRepository.Delete(booking);

            return await _bookingRepository.SaveChangesAsync();
        }
    }
}
