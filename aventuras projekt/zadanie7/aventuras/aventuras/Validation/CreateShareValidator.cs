using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using aventuras.BindingModels;

namespace aventuras.Validation
{
    public class CreateShareValidator : AbstractValidator<CreateShare>
    {
        public CreateShareValidator()
        {
            RuleFor(x => x.PostId).NotNull();
            RuleFor(x => x.UserId).NotNull();
        }
    }
}
