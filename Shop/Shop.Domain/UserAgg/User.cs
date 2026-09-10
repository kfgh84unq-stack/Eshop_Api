using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Text;


namespace Shop.Domain.UserAgg
{
    public class User:AggregateRoot
    {
        public User(string name, string family, string phoneNamber, string email, string password, 
            Gender gender,IDomainUserService domainUser)
        {
            Guard(phoneNamber, email, domainUser);
            Name = name;
            Family = family;
            PhoneNamber = phoneNamber;
            Email = email;
            Password = password;
            Gender = gender;
        }

        public string Name { get;private set; }
        public string Family { get; private set; }
        public string PhoneNamber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Gender Gender { get; private set; }
        public List<UserAddress> Addresses { get; private set; }
        public List<UserRole> Roles { get; private set; }
        public List<Wallet> Wallets { get; private set; }
        public void Edit(string name, string family, string phoneNamber, string email, Gender gender
            ,IDomainUserService domainUser)
        {
            Guard(phoneNamber, email, domainUser);
            Name = name;
            Family = family;
            PhoneNamber = phoneNamber;
            Email = email;
            Gender = gender;
        }
        public static User RegisterUser(string phoneNamber, string email, string password
            , IDomainUserService domainUser)
        {
            return new User("","",phoneNamber, email, password, Gender.None, domainUser);
        }
      
        public void AddAddress(UserAddress address)
        {
            address.UserId = Id;
            Addresses.Add(address);
        }
        public void EditAddress(UserAddress address)
        {
            var oldAddress = Addresses.FirstOrDefault(f => f.Id == address.Id);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("Address not found.");
            Addresses.Remove(oldAddress);
            Addresses.Add(address );
        }
        public void DeleteAddress(long addressId)
        {
            var oldAddress = Addresses.FirstOrDefault(f => f.Id == addressId);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("Address not found.");
            Addresses.Remove(oldAddress);
        }
        public void ChargeWallet(Wallet wallet)
        {
           wallet.UserId = Id;
           Wallets.Add(wallet);
        }
        public void SetRoles(List<UserRole> roles)
        {
           roles.ForEach(f=>f.UserId = Id);
           Roles.Clear();
           Roles.AddRange(roles);
        }
        public void Guard(string phoneNumber,string email,IDomainUserService domainUser)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));
            if (phoneNumber.Length != 11)
                throw new InvalidDomainDataException("شماره تلفن نامعتبر است.");

            if(email.IsValidEmail()==false)
            {
                throw new InvalidDomainDataException("ایمیل نامعتبر است");
            }

            if (phoneNumber != PhoneNamber)
                if (domainUser.IsPhoneNamberExist(phoneNumber))
                    throw new InvalidDomainDataException("شماره تلفن تکراری است.");

            if (email != Email)
                if (domainUser.IsEmailExist(email))
                    throw new InvalidDomainDataException("ایمیل تکراری است.");
        }

    }
}
