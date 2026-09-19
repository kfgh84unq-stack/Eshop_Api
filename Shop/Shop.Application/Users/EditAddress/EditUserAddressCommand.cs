using Common.Application;
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using Common.Domain.ValueObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Users.EditAddress
{
    public class EditUserAddressCommand : IBaseCommand
    {
        public EditUserAddressCommand(long userId, long addressId, string name, string family, PhoneNamber phoneNumber,
            string city, string shire, string postalCode, string postalAddress, string nationalCode)
        {
            UserId = userId;
            AddressId = addressId;
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
        public long AddressId { get; internal set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public PhoneNamber PhoneNumber { get; private set; }
        public string City { get; private set; }
        public string Shire { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string NationalCode { get; private set; }
    }
    
}
