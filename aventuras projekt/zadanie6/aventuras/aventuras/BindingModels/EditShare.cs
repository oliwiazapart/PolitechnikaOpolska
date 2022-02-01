using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace aventuras.BindingModels
{
    public class EditShare
    {
        [Required]
        [Display(Name = "ShareId")]
        public int ShareId { get; set; }

        [Display(Name = "PostId")]
        public int PostId { get; set; }

        [Display(Name = "UserId")]
        public int UserId { get; set; }

        public class EditShareValidator : AbstractValidator<EditShare>
        {
            public EditShareValidator()
            {
                RuleFor(x => x.ShareId).NotNull();
                RuleFor(x => x.PostId).NotNull();
                RuleFor(x => x.UserId).NotNull();
            }
        }


    }
}
