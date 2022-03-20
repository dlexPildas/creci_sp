
using CreciSP.Repository.Context;
using CreciSP.Repository.Repositories;
using System;
using System.Linq;

namespace CreciSP.Domain.Services.Booking
{
    public class BookingRepository : Persist, IBookingRepository
    {
        private readonly DataContext _dataContext;

        public BookingRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
