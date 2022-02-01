using System;
using System.Collections.Generic;
using System.Text;

namespace aventuras.data.sql.DAO
{
    public class Post
    {
        public Post()
        {
            Shares = new List<Share>();
            Ratings = new List<Rating>();
            VisualMedias = new List<VisualMedia>();
        }

        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }
        public int RatingNumber { get; set; }
        public int CommentsNumber { get; set; }
        public bool ActiveStatus { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Share> Shares { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<VisualMedia> VisualMedias { get; set; }
    }
}
