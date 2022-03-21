using _03.CreciSP.Domain.Notifier;
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
        public override ValidationResult ValidationResult()
        {
            return GetValidationResult();
        }
    }
}
