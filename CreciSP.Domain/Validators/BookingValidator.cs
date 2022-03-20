using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using CreciSP.Domain.Models;

namespace CreciSP.Domain.Validators
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(x => x.Date).Must(x => x != DateTime.MinValue).NotNull().NotEmpty().WithMessage(@"Data inválida!");
            RuleFor(x => x.StartTime).NotNull().NotEmpty().WithMessage(@"Informe horário de início!");
            RuleFor(x => x.EndTime).NotNull().NotEmpty().WithMessage(@"Informe horário final!");
            RuleFor(x => x.RoomId).NotNull().NotEmpty().WithMessage(@"Infome a Sala!");
        }
    }
}
