using Common.Domain;

namespace Shop.Domain.OrderAgg
{
    public class OrderAddress:BaseEntity
    {
        public OrderAddress(string name, string family, string phoneNumber, string city,
            string shire, string postalCode, string postalAddress, string nationalCode)
        {
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            City = city;
            Shire = shire;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            NationalCode = nationalCode;
        }

        public long OrderId { get; internal set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string City { get; private set; }
        public string Shire { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string NationalCode { get; private set; }
        public Order Order { get; set; }
    }
}
