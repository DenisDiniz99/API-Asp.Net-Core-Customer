using Api_Customer_Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api_Customer_Domain.Validations
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.Street)
                .NotEmpty().WithMessage("O campo Rua não pode ser vazio")
                .MaximumLength(50).WithMessage("O campo Rua deve conter até 50 caracteres");

            RuleFor(a => a.Number)
                .NotEmpty().WithMessage("O campo Número não pode ser vazio")
                .MaximumLength(7).WithMessage("O campo Número deve conter até 7 caracteres");

            RuleFor(a => a.Neighborhood)
                .NotEmpty().WithMessage("O campo Bairro não pode ser vazio")
                .MaximumLength(50).WithMessage("O campo Bairro deve conter até 50 caracteres");

            RuleFor(a => a.ZipCode)
                .NotEmpty().WithMessage("O campo CEP não pode ser vazio")
                .Length(8).WithMessage("O campo CEP deve conter 8 caracteres");

            RuleFor(a => a.City)
                .NotEmpty().WithMessage("O campo Cidade não pode ser vazio")
                .MaximumLength(50).WithMessage("O campo Cidade deve conter até 50 caracteres");

            RuleFor(a => a.State)
                .NotEmpty().WithMessage("O campo Estado não pode ser vazio")
                .Length(2).WithMessage("O campo Estado deve conter 2 caracteres");
        }
    }
}
