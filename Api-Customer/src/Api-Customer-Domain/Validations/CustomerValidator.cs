using Api_Customer_Domain.Entities;
using FluentValidation;

namespace Api_Customer_Domain.Validations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Gender)
                .NotEmpty().WithMessage("O campo Gênero não pode ser vazio")
                .Length(1).WithMessage("O campo Gênero deve conter somente 1 caracter (M ou F)");

            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("O campo Telefone não pode ser vazio");

            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("O campo Data de Nascimento não pode ser vazio");
        }
    }
}
