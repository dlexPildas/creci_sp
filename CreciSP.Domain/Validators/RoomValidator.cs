using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using CreciSP.Domain.Models;

namespace CreciSP.Domain.Validators
{
    public class RoomValidator :AbstractValidator<Room>
    {
        public RoomValidator()
        {
            RuleFor(x => x.Number).GreaterThan(0).WithMessage(@"Numero da Sala inválido!"); 
            RuleFor(x => x.Capacity).GreaterThan(0).WithMessage(@"Capacidade inválido!"); ;
            RuleFor(x => x.Floor).GreaterThanOrEqualTo(0).WithMessage(@"Andar inválido!");
            RuleFor(x => x.Type).NotNull().WithMessage(@"Informe o Tipo da Sala!");
        }
    }
}
