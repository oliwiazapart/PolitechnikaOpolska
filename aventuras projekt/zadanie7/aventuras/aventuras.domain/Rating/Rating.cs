using System;
using System.Collections.Generic;
using System.Text;
using aventuras.domain.DomainExceptions;

namespace aventuras.domain.Rating
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int UserId { get; private set; }
        public int PostId { get; private set; }
        public int CommentId { get; private set; }
        public int NumericRating { get; private set; }
        public bool UsefulStatus { get; private set; }

        public Rating(int ratingId, int userId, int postId, int commentId, int numericRating, bool usefulStatus)
        {
            RatingId = ratingId;
            UserId = userId;
            PostId = postId;
            CommentId = commentId;
            NumericRating = numericRating;
            UsefulStatus = usefulStatus;

        }

        public Rating(int userId, int postId, int commentId, int numericRating, bool usefulStatus)
        {
            UserId = userId;
            PostId = postId;
            CommentId = commentId;
            NumericRating = numericRating;
            UsefulStatus = usefulStatus;

        }

        public void EditRating(int userId, int postId, int commentId, int numericRating, bool usefulStatus)
        { 
            UserId = userId;
            PostId = postId;
            CommentId = commentId;
            NumericRating = numericRating;
            UsefulStatus = usefulStatus;

        }

    }
}
