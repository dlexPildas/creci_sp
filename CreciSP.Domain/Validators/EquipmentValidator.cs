using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using CreciSP.Domain.Models;

namespace CreciSP.Domain.Validators
{
    public class EquipmentValidator : AbstractValidator<Equipment>
    {
        public EquipmentValidator()
        {
            RuleFor(x => x.Number).GreaterThan(0).WithMessage(@"Numero do Equipamento inválido!"); 
            RuleFor(x => x.Type).NotNull().WithMessage(@"Informe o Tipo do Equipamento!");
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage(@"Descrição inválido!"); 
        }
    }
}
