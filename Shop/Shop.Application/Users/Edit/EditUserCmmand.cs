using Common.Application;
using Common.Application.Validation;
using Microsoft.AspNetCore.Http;
using Shop.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Users.Edit
{
    public class EditUserCmmand : IBaseCommand
    {
        public EditUserCmmand(long userId, string name, string family, string phoneNamber, string email, string password,
            IFormFile? avatar, Gender gender)
        {
            UserId = userId;
            Name = name;
            Family = family;
            PhoneNamber = phoneNamber;
            Email = email;
            Password = password;
            Avatar = avatar;
            Gender = gender;
        }

        public long UserId { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNamber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public IFormFile? Avatar { get; private set; }
        public Gender Gender { get; private set; }
    }
}
