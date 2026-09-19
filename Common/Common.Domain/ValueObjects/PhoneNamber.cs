using Common.Domain.Exceptions;
using Common.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.ValueObjects
{
    public class PhoneNamber
    {
        public PhoneNamber(string value)
        {
            if (string.IsNullOrEmpty(value) || value.IsText() || (value.Length != 11))
                throw new InvalidDomainDataException("شماره تلفن نامعتبر است.");
            Value = value;
        }

        public string Value { get; private set; }
    }
}
