using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using aventuras.BindingModels;


namespace aventuras.Validation
{
    public class EditRatingValidator : AbstractValidator<EditRating>
    {
        public EditRatingValidator()
        {
            RuleFor(x => x.RatingId).NotNull();
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.PostId).NotNull();
            RuleFor(x => x.CommentId).NotNull();
            RuleFor(x => x.NumericRating).NotNull();
            RuleFor(x => x.UsefulStatus).NotNull();
        }
    }
}
