using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aventuras.Mappers;
using aventuras.Validation;
using aventuras.data.sql;
using aventuras.iservices.Rating;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aventuras.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/rating")]
    public class RatingV2Controller : Controller
    {
        private readonly AventurasDbContext _context;
        private readonly IRatingService _ratingService;

        public RatingV2Controller(AventurasDbContext context, IRatingService ratingService)
        {
            _context = context;
            _ratingService = ratingService;
        }


        [HttpGet("{ratingId:min(1)}", Name = "GetRatingById")]
        public async Task<IActionResult> GetRatingById(int ratingId)
        {
            var rating = await _ratingService.GetRatingByRatingId(ratingId);
            if (rating != null)
            {
                return Ok(RatingToRatingViewModelMapper.RatingToRatingViewModel(rating));
            }
            return NotFound();
        }

        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] iservices.Requests.CreateRating createRating)
        {
            var rating = await _ratingService.CreateRating(createRating);

            return Created(rating.RatingId.ToString(), RatingToRatingViewModelMapper.RatingToRatingViewModel(rating));
        }


        [ValidateModel]
        [HttpPatch("edit/{ratingId:min(1)}", Name = "EditRating")]
        public async Task<IActionResult> EditRating([FromBody] iservices.Requests.EditRating editRating, int ratingId)
        {
            await _ratingService.EditRating(editRating, ratingId);

            return NoContent();
        }

        [HttpDelete("{ratingId:min(1)}", Name = "DeleteRating")]
        public async Task<ActionResult<domain.Rating.Rating>> DeleteRating(int ratingId)
        {
            var rating = await _context.Rating.FirstOrDefaultAsync(x => x.RatingId == ratingId);
            if (rating != null)
            {
                _context.Rating.Remove(rating);
                await _context.SaveChangesAsync();
                return NoContent();
            }

            return NotFound();

        }

    }
}
    