using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using aventuras.BindingModels;

namespace aventuras.Validation
{
    public class EditShareValidator : AbstractValidator<EditShare>
    {
        public EditShareValidator()
        {
            RuleFor(x => x.PostId).NotNull();
            RuleFor(x => x.UserId).NotNull();
        }
    }
}
