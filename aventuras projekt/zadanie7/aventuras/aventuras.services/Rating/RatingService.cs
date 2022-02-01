using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using aventuras.iservices.Requests;
using aventuras.iservices.Rating;
using aventuras.idata.Rating;

namespace aventuras.services.Rating
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public Task<domain.Rating.Rating> GetRatingByRatingId(int ratingId)
        {
            return 
                _ratingRepository.GetRating(ratingId);
        }

        public async Task<domain.Rating.Rating> CreateRating(CreateRating createRating)
        {
            var rating = new domain.Rating.Rating(createRating.UserId, createRating.PostId, createRating.CommentId, createRating.NumericRating, createRating.UsefulStatus);
            rating.RatingId = await _ratingRepository.AddRating(rating);
            return rating;
        }

        public async Task EditRating(EditRating createRating, int ratingId)
        {
            var rating = await _ratingRepository.GetRating(ratingId);
            rating.EditRating(createRating.UserId, createRating.PostId, createRating.CommentId, createRating.NumericRating, createRating.UsefulStatus);
            await _ratingRepository.EditRating(rating);
        }
    }
}



