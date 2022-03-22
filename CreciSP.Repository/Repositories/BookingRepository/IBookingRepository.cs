using CreciSP.Domain.Filters;
using CreciSP.Domain.Models;
using CreciSP.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Services.BookingRepository
{
    public interface IBookingRepository : IPersist
    {
        Task<ICollection<Booking>> GetBookingsByFilter(BookingFilter filter);

        Task<Booking> GetBookingById(Guid id);
    }
}
