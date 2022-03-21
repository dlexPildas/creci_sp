using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CreciSP.Domain.Notifier
{
    public abstract class NotifierService : INotifierService
    {
        private readonly ValidationResult _validationResult;
        public abstract ValidationResult ValidationResult();

        protected NotifierService()
        {
            _validationResult ??= new ValidationResult();
        }

        public void AddValidationFailure(string message)
        {
            _validationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        public ValidationResult GetValidationResult()
        {
            return _validationResult;
        }
    }
}
