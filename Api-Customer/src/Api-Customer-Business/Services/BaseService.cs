using Api_Customer_Business.Contracts;
using Api_Customer_Business.Notifications;
using Api_Customer_Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Api_Customer_Business.Services
{
    public abstract class BaseService
    {
        private readonly INotifier _notifier;

        public BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach(var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }

        protected bool Validate<TValidation, TEntity>(TValidation validation, TEntity entity) where TValidation : AbstractValidator<TEntity> where TEntity : Entity
        {
            var result = validation.Validate(entity);

            if (result.IsValid) return true;

            Notify(result);

            return false;
        }
    }
}
