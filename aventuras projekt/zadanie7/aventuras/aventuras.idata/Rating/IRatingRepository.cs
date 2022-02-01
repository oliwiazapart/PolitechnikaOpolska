using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aventuras.idata.Rating
{
    public interface IRatingRepository
    {
        Task<int> AddRating(aventuras.domain.Rating.Rating rating);
        Task<aventuras.domain.Rating.Rating> GetRating(int ratingId);
        Task EditRating(domain.Rating.Rating rating);
    }
}
