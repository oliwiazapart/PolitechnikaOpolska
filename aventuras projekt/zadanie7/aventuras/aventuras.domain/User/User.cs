using System;
using aventuras.common.Enums;
using aventuras.domain.DomainExceptions;

namespace aventuras.domain.User
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; private set; }
        public Gender Gender { get; private set; }
        public string Email { get; private set; }
        public int PostNumber { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public bool ActiveStatus { get; private set; }
        public string AvatarHref { get; private set; }

        public User(int userId, string name, Gender gender, string email, int postNumber, DateTime birthDate, DateTime registrationDate, bool activeStatus, string avatarHref)
        {
            UserId = userId;
            Name = name;
            Gender = gender;
            Email = email;
            PostNumber = postNumber;
            BirthDate = birthDate;
            RegistrationDate = registrationDate;
            ActiveStatus = activeStatus;
            AvatarHref = avatarHref;

        }

        public User(string name, Gender gender, string email, DateTime birthDate)
        {
            if (birthDate >= DateTime.UtcNow)
                throw new InvalidBirthDateException(birthDate);
            Name = name;
            Gender = gender;
            Email = email;
            PostNumber = 0;
            BirthDate = birthDate;
            RegistrationDate = DateTime.UtcNow;
            ActiveStatus = true;

        }

        public void EditUser(string name, Gender gender, string email, DateTime birthDate)
        {
            if (birthDate >= DateTime.UtcNow)
                throw new InvalidBirthDateException(birthDate);
            Name = name;
            Gender = gender;
            Email = email;
            BirthDate = birthDate;

        }

    }

}
