using System;
using System.Collections.Generic;
using System.Text;

namespace aventuras.domain.DomainExceptions
{
    public class InvalidBirthDateException : Exception
    {
        public InvalidBirthDateException(DateTime birthDate) : base(ModifyMessage(birthDate))
        {
        }

        private static string ModifyMessage(DateTime birthDate)
        {
            return $"Invalid birth date {birthDate}.";
        }
    }
}
