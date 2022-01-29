namespace Api_Customer_Domain.Entities
{
    public class Address : Entity
    {
        public Address() { }

        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
