using Common.Application;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Users.RegisterUser
{
    public class RegisrterUserAddress : IBaseCommand
    {
        public RegisrterUserAddress(PhoneNamber phoneNamber, string password)
        {
            PhoneNamber = phoneNamber;
            Password = password;
        }

        public PhoneNamber PhoneNamber{ get; private set; }
        public string Password { get; private set; }
    }

}
