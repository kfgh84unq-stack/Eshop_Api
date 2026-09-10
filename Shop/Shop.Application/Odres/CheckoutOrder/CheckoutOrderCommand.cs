using Common.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Odres.CheckoutOrder
{
    public class CheckoutOrderCommand: IBaseCommand
    {
        public CheckoutOrderCommand(long userId, string name, string family, string phoneNumber,
            string city, string shire, string postalCode, string postalAddress, string nationalCode)
        {
            UserId = userId;
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            City = city;
            Shire = shire;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            NationalCode = nationalCode;
        }

        public long UserId { get; internal set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string City { get; private set; }
        public string Shire { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string NationalCode { get; private set; }
    }
}
