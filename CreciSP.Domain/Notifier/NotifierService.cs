using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CreciSP.Domain.Notifier
{
    public class NotifierService : INotifierService
    {
        private readonly ValidationResult _validationResult;
        
        public NotifierService()
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
        
        public virtual ValidationResult ValidationResult()
        {
            return null;
        }
    }
}
