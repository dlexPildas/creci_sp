using FluentValidation.Results;

namespace _03.CreciSP.Domain.Notifier
{
    public interface INotifierService
    {
        ValidationResult ValidationResult();
    }
}
