using Api_Customer_Domain.Enums;
using Api_Customer_Domain.Validations.Documents;
using Api_Customer_Domain.ValuesObject;
using FluentValidation;

namespace Api_Customer_Domain.Validations
{
    public class DocumentValidator : AbstractValidator<Document>
    {
        public DocumentValidator()
        {
            When(c => c.Type == EDocumentType.cpf, () =>
            {
                RuleFor(c => c.Number.Length)
                  .Equal(CpfValidation.CpfSize).WithMessage("O campo Documento (CPF) deve conter 11 caracteres");
                RuleFor(c => CpfValidation.Validate(c.Number))
                   .Equal(true).WithMessage("O campo Documento (CPF) não é válido");
            });

            When(c => c.Type == EDocumentType.cnpj, () =>
            {
                RuleFor(c => c.Number.Length)
                    .Equal(CnpjValidation.CnpjSize).WithMessage("O campo Documento (CNPJ) deve conter 14 caracteres");
                RuleFor(c => CnpjValidation.Validate(c.Number))
                    .Equal(true).WithMessage("O campo Documento (CNPJ) não é válido");
            });
        }
    }
}
