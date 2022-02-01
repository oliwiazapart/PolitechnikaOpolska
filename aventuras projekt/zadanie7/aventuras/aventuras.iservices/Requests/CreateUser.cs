using System;
using System.Collections.Generic;
using System.Text;
using aventuras.common.Enums;

namespace aventuras.iservices.Requests
{
    public class CreateUser
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
