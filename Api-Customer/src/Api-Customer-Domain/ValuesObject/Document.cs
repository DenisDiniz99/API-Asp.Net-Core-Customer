using Api_Customer_Domain.Enums;

namespace Api_Customer_Domain.ValuesObject
{
    public class Document
    {
        public EDocumentType Type { get; set; }
        public string Number { get; set; }
    }
}
