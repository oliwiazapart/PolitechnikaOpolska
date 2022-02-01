using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace aventuras.BindingModels
{
    public class EditRating
    {
        [Required]
        [Display(Name = "RatingId")]
        public int RatingId { get; set; }

        [Display(Name = "UserId")]
        public int UserId { get; set; }

        [Display(Name = "PostId")]
        public int PostId { get; set; }

        [Display(Name = "CommentId")]
        public int CommentId { get; set; }

        [Display(Name = "NumericRating")]
        public int NumericRating { get; set; }

        [Display(Name = "UsefulStatus")]
        public bool UsefulStatus { get; set; }
    }
}
