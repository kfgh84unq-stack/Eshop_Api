using Common.Application;
using Shop.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Users.Create
{
    public class CreateUserCommand : IBaseCommand
    {
        public CreateUserCommand(string name, string family, string phoneNamber, string email, string password, Gender gender)
        {
            Name = name;
            Family = family;
            PhoneNamber = phoneNamber;
            Email = email;
            Password = password;
            Gender = gender;
        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNamber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Gender Gender { get; private set; }
    }
}
