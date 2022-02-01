using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aventuras.common.Enums;

namespace aventuras.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public int PostNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool ActiveStatus { get; set; }
        public string AvatarHref { get; set; }
    }
}
