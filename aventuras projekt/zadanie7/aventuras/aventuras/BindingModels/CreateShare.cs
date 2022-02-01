using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace aventuras.BindingModels
{
    public class CreateShare
    {
        [Required]
        [Display(Name = "ShareId")]
        public int ShareId { get; set; }

        [Required]
        [Display(Name = "PostId")]
        public int PostId { get; set; }

        [Required]
        [Display(Name = "UserId")]
        public int UserId { get; set; }
    }
}
