using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;

namespace Shop.Domain.UserAgg
{
    public class UserAddress : BaseEntity
    {
        public UserAddress( string name, string family, PhoneNamber phoneNumber, string city, string shire,
            string postalCode, string postalAddress, string nationalCode)
        {
            Guard(name, family, phoneNumber, city, shire, postalCode, postalAddress, nationalCode);

            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            City = city;
            Shire = shire;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            NationalCode = nationalCode;
            ActiveAddress = false;
        }

        public long UserId { get; internal set; }
        public string Name { get;private set; }
        public string Family { get; private set; }
        public PhoneNamber PhoneNumber { get; private set; }
        public string City { get; private set; }
        public string Shire { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string NationalCode { get; private set; }
        public bool ActiveAddress { get; private set; }
        public void Edit(string name, string family, PhoneNamber phoneNumber, string city, string shire,
           string postalCode, string postalAddress, string nationalCode)
        {
            Guard(name, family, phoneNumber, city, shire, postalCode, postalAddress, nationalCode);

            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            City = city;
            Shire = shire;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            NationalCode = nationalCode;
        }

        public void SetActive()
        {
            ActiveAddress = true;
        }
        private void Guard( string name, string family, PhoneNamber phoneNumber, string city, string shire,
           string postalCode, string postalAddress, string nationalCode)
        {
            if (phoneNumber == null)
                throw new InvalidDomainDataException();
            NullOrEmptyDomainDataException.CheckString(name, nameof(name));
            NullOrEmptyDomainDataException.CheckString(family, nameof(family));
            NullOrEmptyDomainDataException.CheckString(city, nameof(city));
            NullOrEmptyDomainDataException.CheckString(shire, nameof(shire));
            NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
            NullOrEmptyDomainDataException.CheckString(postalAddress, nameof(postalAddress));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));

            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException("کد ملی معتبر نیست.");
        }
    }
}
