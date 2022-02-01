using System;
using System.Collections.Generic;
using System.Text;

namespace aventuras.data.sql.DAO
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public int NumericRating { get; set; }
        public bool UsefulStatus { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        public virtual Comment CommentComment { get; set; }

    }
}
