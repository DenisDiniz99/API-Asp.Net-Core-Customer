using System;
using System.ComponentModel.DataAnnotations;

namespace Api_Customer_Api.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.")]
        public string LastName { get; set; }

        public string FullName => $"FirstName" + $"LastName";

        [DataType(DataType.Date, ErrorMessage = "O campo {0} está em um formato inválido")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1, ErrorMessage = "O campo {0} deve conter {1} caracter")]
        public string Gender { get; set; }

        public int DocumentType { get; set; }

        public string DocumentNumber { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "O campo {0} está em um formato inválido")]
        public string Phone { get; set; }

        public bool Active { get; set; }

        [DataType(DataType.Date, ErrorMessage = "O campo {0} está em um formato inválido")]
        public DateTime RegistrationDate { get; set; }

        public Guid AddressId { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
