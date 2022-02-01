using aventuras.common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace aventuras.data.sql.DAO
{
    public class User
    {
        public User()
        {
            Posts = new List<Post>();
            Shares = new List<Share>();
            Ratings = new List<Rating>();

        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public int PostNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool ActiveStatus { get; set; }
        public string AvatarHref { get; set; }


        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Share> Shares { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }

    }
}
