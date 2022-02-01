using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using aventuras.iservices.Requests;

namespace aventuras.iservices.Rating
{
    public interface IRatingService
    {
        Task<aventuras.domain.Rating.Rating> GetRatingByRatingId(int ratingId);
        Task<aventuras.domain.Rating.Rating> CreateRating(CreateRating createRating);
        Task EditRating(EditRating createRating, int ratingId);
    }
}
