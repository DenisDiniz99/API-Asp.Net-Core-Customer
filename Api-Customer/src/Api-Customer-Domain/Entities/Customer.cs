using Api_Customer_Domain.ValuesObject;
using System;

namespace Api_Customer_Domain.Entities
{
    public class Customer : Entity
    {
        public Customer() { }


        public FullName Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public Document Document { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
    }
}
