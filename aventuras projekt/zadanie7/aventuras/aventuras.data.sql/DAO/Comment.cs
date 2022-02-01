using System;
using System.Collections.Generic;
using System.Text;

namespace aventuras.data.sql.DAO
{
    public class Comment
    {

        public Comment()
        {
            SubComments = new List<Comment>();
            Ratings = new List<Rating>();

        }

        public int CommentId { get; set; }
        public int? CommentCommentId { get; set; }
        public string CommentBody { get; set; }
        public DateTime CommentCreationDate { get; set; }
        public DateTime CommentEditDate { get; set; }
        public bool ActiveStatus { get; set; }

        public virtual Comment CommentComment { get; set; }

        public virtual ICollection<Comment> SubComments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
