using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using aventuras.idata.Rating;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;

namespace aventuras.data.sql.Rating
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AventurasDbContext _context;

        public RatingRepository(AventurasDbContext context)
        {
            _context = context;
        }


        public async Task<int> AddRating(domain.Rating.Rating rating)
        {
            var ratingDAO = new DAO.Rating
            {
                UserId = rating.UserId,
                PostId = rating.PostId,
                CommentId = rating.CommentId,
                NumericRating = rating.NumericRating,
                UsefulStatus = rating.UsefulStatus
            };

            await _context.AddAsync(ratingDAO);
            await _context.SaveChangesAsync();
            return ratingDAO.RatingId;
        }

        public async Task<domain.Rating.Rating> GetRating(int ratingId)
        {
            var rating = await _context.Rating.FirstOrDefaultAsync(x => x.RatingId == ratingId);
            return new domain.Rating.Rating(rating.RatingId,
                rating.UserId,
                rating.PostId,
                rating.CommentId,
                rating.NumericRating,
                rating.UsefulStatus
                );;

        }

        public async Task EditRating(domain.Rating.Rating rating)
        {
            var editRating = await _context.Rating.FirstOrDefaultAsync(x => x.RatingId == rating.RatingId);
            editRating.UserId = rating.UserId;
            editRating.PostId = rating.PostId;
            editRating.CommentId = rating.CommentId;
            editRating.NumericRating = rating.NumericRating;
            editRating.UsefulStatus = rating.UsefulStatus;
            await _context.SaveChangesAsync();
        }

    }

}




