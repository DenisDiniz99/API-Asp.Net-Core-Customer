using Api_Customer_Domain.ValuesObject;
using FluentValidation;

namespace Api_Customer_Domain.Validations
{
    public class FullNameValidator : AbstractValidator<FullName>
    {
        public FullNameValidator()
        {
            RuleFor(n => n.FisrtName)
                .NotEmpty().WithMessage("O campo Nome não pode ser vazio")
                .MaximumLength(50).WithMessage("O campo Nome deve conter até 50 caracteres");
            RuleFor(n => n.LastName)
                .NotEmpty().WithMessage("O campo Sobrenome não pode ser vazio")
                .MaximumLength(50).WithMessage("O campo Sobrenome deve conter até 50 caracteres");
        }
    }
}
