using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using CreciSP.Domain.Models;

namespace CreciSP.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage(@"Informe o Nome!"); 
            RuleFor(x => x.Cpf).NotNull().NotEmpty().WithMessage(@"Cpf inválido!"); ;
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage(@"Informe o E-mail!");
            RuleFor(x => x.Password).MinimumLength(6).NotNull().NotEmpty().WithMessage(@"Infome a Senha!");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage(@"Senha deve ter no mínimo 6 digitos!");
            RuleFor(x => x.Type).NotNull().WithMessage(@"Informe o Tipo de Usuário!");
        }
    }
}
