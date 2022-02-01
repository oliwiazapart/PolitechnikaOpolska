using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using aventuras.BindingModels;

namespace aventuras.Validation
{
    public class EditUserValidator : AbstractValidator<EditUser>
    {
        public EditUserValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.BirthDate).NotNull();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Gender).NotNull();
        }
    }
}
