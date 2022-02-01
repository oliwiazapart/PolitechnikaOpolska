using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aventuras.ViewModels;

namespace aventuras.Mappers
{
    public class RatingToRatingViewModelMapper
    {
        public static RatingViewModel RatingToRatingViewModel(domain.Rating.Rating rating)
        {
            var ratingViewModel = new RatingViewModel
            {
                RatingId = rating.RatingId,
                UserId = rating.UserId,
                PostId = rating.PostId,
                CommentId = rating.CommentId,
                NumericRating = rating.NumericRating,
                UsefulStatus = rating.UsefulStatus

            };

            return ratingViewModel;
        }
            
    }
}
