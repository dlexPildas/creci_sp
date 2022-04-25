using _03.CreciSP.Domain.Notifier;
using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Application.Services.BookingService
{
    public interface IBookingService : INotifierService
    {
        Task<bool> Create(Booking booking);

        Task<ICollection<Booking>> GetBookingsByFilter(BookingFilter bookingFilter);

        Task<bool> DeleteBooking(Guid id, bool isAdmintrator);

    }
}
